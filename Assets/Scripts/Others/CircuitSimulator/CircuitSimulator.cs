using System;
using System.Collections.Generic;
using SharpCircuit;

namespace Laboratories.ElectricalCircuit
{
    public class CircuitSimulator : ICircuitSimulator
    {
        public int CountStep { get; set; }
        public double TimeStep { get; set; }

        private Circuit circuit;

        private List<IElement> elements;
        private List<int> indexs;

        private bool isNeedRebuild = false;

        public CircuitSimulator()
        {
            elements = new List<IElement>();
            indexs = new List<int>();
            TimeStep = 5E-5;
            CountStep = 1;

            Rebuild();
        }

        public IElement Create(ICircuitElement circuitElement, params ICircuitJoint[] joints)
        {
            var element = new Element(circuitElement, joints);
            elements.Add(element);
            isNeedRebuild = true;
            return element;
        }

        public IElement Create(ICircuitElement circuitElement, params int[] idJoints)
        {
            var joints = new CircuitJoint[idJoints.Length];
            for (int i = 0; i < joints.Length; i++)
                joints[i] = new CircuitJoint() { Id = idJoints[i]};

            return Create(circuitElement, joints);
        }

        public void Process()
        {
            if (isNeedRebuild)
                Rebuild();

            circuit.needAnalyze();
            circuit.doTicks(CountStep);
        }

        public void Rebuild()
        {
            foreach (var element in elements)
                element.Reset();

            circuit = new Circuit();
            circuit.timeStep = TimeStep;
            AssembleCircuit();
            isNeedRebuild = false;
        }

        public void Remove(IElement element)
        {
            isNeedRebuild = elements.Remove(element);
        }

        public void RemoveConnectedWithJoint(ICircuitJoint joint)
        {
            isNeedRebuild = elements.RemoveAll(x => x.GetJoints().Contains(joint)) > 0;
        }

        public void Clear()
        {
            elements.Clear();
            isNeedRebuild = true;
        }

        private void AssembleCircuit()
        {
            indexs.Clear();

            foreach (var firstElement in elements)
                foreach (var secondElement in elements)
                    ConnectTwoElements(firstElement, secondElement);

            ConnectFreeLeadsInElements();
        }

        private void ConnectTwoElements(IElement firstElement, IElement secondElement)
        {
            if (firstElement == secondElement)
                return;

            var firstJoints = firstElement.GetJoints().ToArray();
            var secondJoints = secondElement.GetJoints().ToArray();
            for (int i = 0; i < firstJoints.Length; i++)
            {
                for (int j = 0; j < secondJoints.Length; j++)
                {
                    if (firstJoints[i].Id == secondJoints[j].Id)
                    {
                        UnityEngine.Debug.Log(String.Format("Connect: {0} to {1} ({2},{3}) socket id: {4}",
                        firstElement.CircuitElement.GetType().Name, secondElement.CircuitElement.GetType().Name,
                        i, j, firstJoints[i].Id));

                        circuit.AddElement(firstElement.CircuitElement);
                        circuit.AddElement(secondElement.CircuitElement);

                        circuit.Connect(firstElement.CircuitElement, i, secondElement.CircuitElement, j);
                        if (!indexs.Contains(firstJoints[i].Id))
                            indexs.Add(firstJoints[i].Id);
                    }
                }
            }
        }

        private void ConnectFreeLeadsInElements()
        {
            var attachedElements = elements.FindAll(x => circuit.elements.Contains(x.CircuitElement));
            foreach (var element in attachedElements)
            {
                var joints = element.GetJoints().ToArray();
                for (int i = 0; i < joints.Length; i++)
                    if (!indexs.Contains(joints[i].Id))
                        circuit.Connect(element.CircuitElement, i, element.CircuitElement, i);
            }
        }
    }
}