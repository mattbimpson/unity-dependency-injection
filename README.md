# Dependency Injection with Unity #

### What is this repository for? ###

This project is a simple WebApi solution demonstrating DI using Unity.

* The unity container is managed in UnityContainerManager (App_Start folder).
* It is then initialised in WebApiConfig.cs, with the following two lines of code;

IUnityContainer container = UnityContainerManager.Current.GetContainer();
DependencyResolver.SetResolver(new UnityDependencyResolver(container));

Important: For controllers inheriting from 'Controller', use the Nuget package "Unity.Mvc3". For controllers inheriting from 'ApiController', use the "Unity" package (v4) and use the following line of code to set the dependency resolver:

GlobalConfiguration.Configuration.DependencyResolver = new Microsoft.Practices.Unity.WebApi.UnityDependencyResolver(container);

After configuring the container manager, you can then register the types in code, or in the Web.Config like this;

<unity xmlns="http://schemas.microsoft.com/practices/2010/unity">
    <container>
      <register type="BusinessObjects.IService, BusinessObjects" mapTo="Services.MyService, Services" />
    </container>
 </unity>

The following line should also be placed at the top of the config file, in <configSections> to show we are using unity;

<section name="unity" type="Microsoft.Practices.Unity.Configuration.UnityConfigurationSection, Microsoft.Practices.Unity.Configuration" />
 
 All should be working now, simply inject your dependency in a constructor (as in HomeController.cs).