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
Injection is a way of telling GruInject where an instance should be provided.
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
The simplest way of starting GruInject is shown below. In this example, GruInject was started with default recommended settings.
```C#
__gruInject = new API.GruInject();
_gruInject.Start();
```
There is a way to use custom attributes instead of default ones:
```C#
_gruInject = new API.GruInject(
  new List<Type>() {typeof(AutoSpawnAttribute)},
  new List<Type>() {typeof(InjectAttribute)},
  typeof(RegisterAsSingleInstanceAttribute),
  typeof(RegisterInstanceAttribute));
_gruInject.Start();
```
Start method provides two useful options:
```C#
 _gruInject.Start(allowOnlyRegisteredInstances:false);
```
By setting this option to false - we allow GruInject to create instances that were not declared using attributes, it will try to create instances using one of their constructors. \
This option is rather dangerous as it can lead to instances with default values, eg. when int value is used in the constructor. \
It's important to note that interfaces will be excluded from auto-create as there is no simple option to determine which implementation to use.
**This option is true by default**
```C#
_gruInject.Start(enableCircularDependencyDetection:true);
```
By setting this option to true, you can enable a tool for detecting circular dependencies in your services. \
Circular dependency can happen when One service let's call it A needs Service B to work but Service B requires Service A to work. This is the simplest example but there can be multiple classes in between that create chains that are hard to find. \
This option provides a way to find these chains (but it can be costly) \
**Enable this option only if needed.**

## How can I use those instances that require Inject in tests?
For simple tests that don't require a full start ***GruInjectTestingTool*** was made.
```C#
private GruInjectTestingTool _gruInjectTestingTool;

[SetUp]
public void SetUp()
{
    _gruInjectTestingTool = new GruInjectTestingTool();
}

[Test]
public void When_InstanceRequested_Then_InstanceIsNotNull()
{
    var instance = _gruInjectTestingTool.GetInstance<YourInstance>();
    Assert.NotNull(instance);
}

[TearDown]
public void TearDown()
{
    _gruInjectTestingTool.Dispose();
}
```
As you can see in the given example, in SetUp the "GruInjectTestingTool" was created and in TearDown it was Disposed of - those steps are important to have test independence.
In the test, you can simply grab an instance by use of "_gruInjectTestingTool.GetInstance<YourInstance>()". The instances provided this way will be initialized but only required services will be started.

### What if I require a full start of GruInject?
You can also use ***GruInjectTestingTool*** simply use _gruInjectTestingTool.Start() in SetUp or Test - it will start all services as it would normally do.
After this, you are ready to grab your instance as you would do with ***GruInjectTestingTool***.
```C#
[SetUp]
public void SetUp()
{
    _gruInjectTestingTool = new GruInjectTestingTool();
    _gruInjectTestingTool.Start();
}
```
### What about Mocks? Can I use those or a dummy, instead of actual services?
Sure here is how:
```C#
[SetUp]
public void SetUp()
{
    _gruInjectTestingTool = new GruInjectTestingTool();
    _gruInjectTestingTool.AddFakeInstance<IMyActualClass>(new MyDummy());
    _gruInjectTestingTool.Start();
}
```
As you can see we are telling ***GruInjectTestingTool*** that instead of providing "IMyActualClass" he should use the provided instance (that must be an implementation of IMyActualClass)
>[!Warning]
>It's important to note that it's best to provide all fake instances before Starting ***GruInjectTestingTool***.
>Starting before providing may result in starting some services with original implementation and the rest with fake - it all depends on the declaration type and moment of instance request.

### In what order this is happening?
It all starts with 
```C#
_gruInject = new API.GruInject();
_gruInject.Start();
```
The start will result in the spawn of ***[AutoSpawn]*** marked services and all services they require to work. \
All other services will be made when required. 

### In what order insides of the instance are initialized?
1. Fields and Properties
2. Constructor
3. Methods
4. Methods with attributes on parameters

