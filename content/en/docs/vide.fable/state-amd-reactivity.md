---
title: "State and Reactivity"
description: "State and Reactivity"
lead: ""
draft: false
images: []
weight: 400
toc: true
---

## A Simple Counter

Imagine the following goal: A user can click on a button, and the click count is visualized. This simple task involves **state**, which is: A changing value over time, preserved from one to another evaluation.

Let's begin with a skeleton of the view:

```fsharp
vide {
    p {
        button { "Click me!" }
    }
    "You clicked the button n times."
}
```

## Declaring State

Now we need a value that stores the click count. In Vide, `Vide.ofMutable value` is used to declare state:


```fsharp
vide {
    let! count = Vide.ofMutable 0
    (* ... *)
}
```

A value of `0` is passed to `ofMutable`, which will be the initial value bound to the **count** identifier.

Note the exclamation mark **!** suffixing the **let**: You always have to use `let! = ` (instead of just `let = `) when dealing with `Vide.ofMutable` or other state-aware functions.

{{< alert icon="👉" >}}
Later we will see that it's possible to place state declarations at any place in the code, which has advantages when it comes to components and composition.
{{< /alert >}}


## Handling Events

In order to react to click events, the button has a `onclick` extension that takes a callback:

```fsharp
button.onclick(fun _ -> count.Value <- count.Value + 1) {
    "Click me!"
}
```

The click handler increments the counter's `Value`. As an alternative to an assignment, `counter.Set(count.Value + 1)` can be used, too.

{{< alert icon="⚡" >}}
As for **reactivity**, there is nothing more to do. The view will automatically re-evaluate itself synchronousely.
{{< /alert >}}

## Visualizing Click Count

The click count can now be visualized using `counter.Value` in an interpolated string. Here's the final result:

```fsharp
vide {
    let! count = Vide.ofMutable 0

    p {
        button.onclick(fun _ -> count.Value <- count.Value + 1) {
            "Click me!"
        }
    }
    $"You clicked the button {count.Value} times."
}
```
