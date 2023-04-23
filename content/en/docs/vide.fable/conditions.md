---
title: "Conditions (if-else)"
description: "Conditions (if-else)"
lead: ""
date: 2020-10-13T15:21:01+02:00
lastmod: 2020-10-13T15:21:01+02:00
draft: false
images: []
weight: 500
toc: true
---

Let's extend the "Cats and Dogs" counter again: The user's patience shall be rewarded when he counts many cats and dogs by a well-intentioned message:

```fsharp
let! count = Vide.ofMutable 0

button.onclick(fun _ -> count.Value <- count.Value + 1) {
    $"Counting {elementName}: ({count.Value})"
}

(* ... *)
```

## Using 'hidden'

A simple, yet working solution for that is to hide the message conditionally by using the `hidden` attribute, which takes a boolean as argument:

```fsharp
p.hidden(count.Value % 5 <> 0) {
    "...keep counting!"
}
```

## Using 'if'

While using `hidden` is valid for such simple use cases, it a disadvantage: The hidden element(s) sit always in the DOM, which can lead to performance issues, layout problems, eager loading issues, etc. Working around those issues can lead to new issues, or makes writing and understanding the code harder.

These issues are adressed by using the language-level construct `if` and `else` that actually work on DOM-level:

```fsharp
if count.Value % 5 = 0 then
    p { "...keep counting!" }
else
    Vide.elseForget
```

In this case, the `p` element in only inserted in the DOM when the condition is met, and removed otherwise.

## else: Preserve or Forget

The else-branch used here (`Vide.elsePreserve`) cannot be omitted and this, has to be specified by the developer. To understand that,


It is a choice of 2 behaviours: When the else-branch has to be taken,

* is mandatory


<!-- TODO. Docu: The state can get lost because they are not compatible -->
