---
title: "Hosting a Vide App"
description: "TODO"
lead: ""
date: 2020-10-13T15:21:01+02:00
lastmod: 2020-10-13T15:21:01+02:00
draft: false
images: []
weight: 300
toc: true
---

## The application instance

Every Vide application starts by creating a new application instance with the `VideApp.Fable.createAndStart` function:

```fsharp
open Browser
open Vide

let host = document.getElementById("app")
let rootView = (* ... *)
let app = VideApp.Fable.createAndStart host rootView
```
