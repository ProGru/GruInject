using System;
using GruInject.API.Attributes;
using UnityEngine;

namespace GruInject.GruInject.Example
{
    [AutoSpawn]
    public class AutoSpawnedClass1 : IDisposable
    {
        [Inject] private ClassSignedForInjection _classSigned;
        //[Inject] private NotRegisteredClass _notRegisteredClass; //If You uncomment me i will be not injected and exception will happen
        //But you can allow not registered class in GruInjectStart - check this class for more info
        
        public AutoSpawnedClass1()
        {
            Debug.Log($"I {this.GetType()} was spawned");
            Debug.Log($"My field {_classSigned.GetType()} was injected {_classSigned!= null}");
            Debug.Log($"And fields of injected class {_classSigned.GetType()} type of {_classSigned.SecondClass} also was injected {_classSigned.SecondClass != null}");
            Debug.Log($"And fields of this class were injected {_classSigned.SecondClass.ThirdClass != null}");
            
            //order of initialization
            //First fields and properties
            //Then Ctor 
            //Then methods 
            //Then methods with attribute ond parameters
        }

        [Inject]
        public void MyMethodWithInject()
        {
            Debug.Log("Hey i am called!");
        }

        public void MyMethodWithInject([Inject] ClassSignedForInjection value)
        {
            Debug.Log($"I am method and i was called with value {value.GetType()}");
        }

        [Inject]
        public void MyMethodWithParam(ClassSignedForInjection value)
        {
            Debug.Log($"I am method with param and i was called with value {value.GetType()}");

        }
        
        public void Dispose()
        {
        }
    }
}