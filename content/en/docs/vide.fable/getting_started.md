---
title: "Getting Started"
description: "TODO"
lead: ""
date: 2020-10-13T15:21:01+02:00
lastmod: 2020-10-13T15:21:01+02:00
draft: false
images: []
weight: 200
toc: true
---

## Prerequisites

Vide for Fable relies on the F# to JavaScript compiler [Fable](https://fable.io/), which required both `dotnet` and `node / npm` in this

* Node 18 + npm 8
* dotnet SDK 6

There are 3 major IDEs that have dotnet, F# and node support:

* VSCode with Ionide extension
* Visual Studio 2022
* JetBrains Rider


## Creating a Vide for Fable Application

In this section we will introduce how to scaffold a Vide SPA (Single Page Application) on your local machine. The created project will be using a build setup based on [Vite](https://vitejs.dev/guide/).

Make sure you have the correct versions of the dotnet SDK and Node.js installed, then run the following command in your command line:

```bash
dotnet new -i Vide.Fable.Templates
```

{{< alert icon="👉" >}}
If you have a dotnet SDK version >= 7, you might be prompted with a message stating that `dotnet new -i` is deprecated. This is ok as long as the template is installed correctly. Otherwise, use the recommended way in the message for installing new templates.
{{< /alert >}}

This will install the *Vide for Fable* templates that can be used for scaffolding new projects. You can can check the templates available by executing `dotnet new --list`:

```plaintext
Template Name                        Short Name           Language
-----------------------------------  -------------------  ----------
Vide for Fable (minimal) with Vite   vide.fable.minimal   F#
```

Now it's time to create a new *Vide for Fable* project:

```bash
dotnet new vide.fable.minimal -n HelloVideFable
```

Not it's time to build and run the project:

```bash
cd HelloVideFable
npm i
npm start
```

This will install all npm dependencies and also restore the dotnet tools, which is the Fable compiler for this template. After `npm start`, the Fable compiler and the Vite dev server whatch the files changed on disk and do the hard work in the background for you.

The app can be viewed in you browser on
[http://localhost:3000/](http://localhost:3000/)

Now have your first *Vide for Fable* project running! When you are ready to ship your app to production, run the following:

```bash
npm run build
```

{{< alert icon="❤️" >}}
As your project grows in code size and npm/dotnet dependencies, you should have a look at [Femto](https://github.com/Zaid-Ajaj/Femto), which is a dotnet CLI tool for managing npm packages used by Fable bindings.
{{< /alert >}}

## Alternative: Include Vide.Fable in your Existing Project

Instead of creating a new new *Vide for Fable*" app, you can simply add the [Vide.Fable](https://www.nuget.org/packages/Vide.Fable) NuGet package to an existing Fable project and start using it!
