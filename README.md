# GruInject
GruInject is a dependency injection framework for C# Unity applications. It provides a flexible and powerful way to manage dependencies in your codebase.
Its main purpose is to be used in prototypes, as it can help iterate faster.
## How to start?
To start with GruInject you need to understand a few principles:
### Declaration
A declaration is a way of saying which services can be injected and how to create an instance of that class.
- **[RegisterInstance]** - this attribute on a class says that each time someone requests it, a new instance will be provided
- **[RegisterAsSingleInstance]** - this attribute on a class says that each request will provide the same instance (but this instance will be created only if someone requests it)
- **[AutoSpawn]** - this attribute on a class says that on GruInject service Start instance of this class will spawn and each time someone requests an instance of this type the same instance will be provided.
### Startign GruInject Service
GruInject is meant to start before all entities that are going to use it.
For this purpose in the provided example class "GruInjectStart" uses [DefaultExecutionOrder] attribute, and the actual GruInject service starts happening in Awake.
You can use GruInjectStart to start or come up with your way to ensure that GruInject is started before entities that depend on it.
### Injection
Injection is a way of telling GruInject that he should provide an instance in this place.
>[!Warning]
>**[Inject]** can't be used everywhere. 
>It works only on entities:
>- created by GruInject (by Declaration, or creation of unregistered instances more details on it below)
>- inheritors of GruMonoBehaviour and GruMonoBehaviourEditMode (important when overriding Awake call base class)

**[Inject]** attribute can be used on:
- Fields,
- Properties,
- Methods (it will call them with instances they require),
- Constructors,
- Parameters of methods and Constructors

### How to start a summary
So the easiest way to start is: 
1. Put **GruInjectStart** on the scene
2. Declare the service you want to inject eg. **[AutoSpawn]** on a class
3. Create client of injection eg. **[Inject]** attribute on property in class that inherit from **GruMonoBehaviour** and put this instance on scene
4. Press Play and enjoy your injected instance in the client.

## Start GruInject details
```C#
_gruInject = new API.GruInject(
                new List<Type>() {typeof(AutoSpawnAttribute)},
                new List<Type>() {typeof(InjectAttribute)});
_gruInject.Start();
```
In this example, we are telling GruInject that its attribute for auto spawning is the "AutoSpawnAttribute" class, the attribute for places needed injection is the "InjectAttribute" class and it should Start with default values. \
As you can see you can declare your own or use more than one attribute for auto-spawn services and injecting purposes. \
GruInject can be started in two more options:
```C#
 _gruInject.Start(allowOnlyRegisteredInstances:false);
```
By setting this option to false - we allow GruInject to create instances that were not declared using attributes, it will try to create instances using one of their constructors. \
This option is rather dangerous as it can lead to instances with default values, eg. when int value is used in the constructor. \
**This option is true by default**
```C#
_gruInject.Start(enableCircularDependencyDetection:true);
```
By setting this option to true, you can enable a tool for detecting circular dependencies in your services. \
Circular dependency can happen when One service let's call it A needs Service B to work but Service B requires Service A to work. This is the simplest example but there can be multiple classes in between that create chains that are hard to find. \
This option provides a way to find these chains (but it can be costly) \
**Enable this option only if needed.**

## How can I use those instances that require Inject in tests?
Its simple use:
```C#
GruInjStatic.Get<YourInstance>();
```
To get instances and GruInject with initialize it (by creating only required instances)

In your test TearDown use:
```C#
GruInjStatic.Reset();
```
It will clear the container. 

You can also create and start GruInject if your test requires a full start:
```C#
        private API.GruInject _gruInject;

        [SetUp]
        public void SetUp()
        {
            _gruInject = new API.GruInject(
                new List<Type>() {typeof(AutoSpawnAttribute)},
                new List<Type>() {typeof(InjectAttribute)});
            _gruInject.Start();
        }
```
then in test use:
```C#
var instance = _gruInject.GetInstance<YourInstance>();
```
to acquire instance

In your TearDown use:
```C#
       [TearDown]
        public void TearDown()
        {
            _gruInject.Stop();
        }
```
to clear container.
