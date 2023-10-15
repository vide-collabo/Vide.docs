---
title: "Components"
weight: 900
---

As an extension to the previous counter, cats 🐈 and dogs 🐕 shall be counted. Here is a first approach:

```fsharp
vide {
    // cat counter
    div {
        let! count = ofMutable {0}

        button.onclick(fun _ -> count.Value <- count.Value + 1) {
            "Count cats!"
        }
        $"cats: {count.Value}"
    }

    // dog counter
    div {
        let! count = ofMutable {0}

        button.onclick(fun _ -> count.Value <- count.Value + 1) {
            "Count dogs!"
        }
        $"dogs: {count.Value}"
    }
}
```

## Functions as Components

While this works, it's obvious that the counter code was copied and is now - apart from their names like **dog** or **cat** - redundant. This can be fixed easily by extracting the counter code into a function:

```fsharp
let counter elementName = vide {
    div {
        let! count = ofMutable {0}

        button.onclick(fun _ -> count.Value <- count.Value + 1) {
            $"Count %s{elementName}!"
        }
        $"{elementName}: {count.Value}"
    }
}
```

The component can be used like any other HTML element in the final view:

```fsharp
vide {
    counter "cats"
    counter "dogs"
}
```

## Templates and Slots

Instead of just passing strings, numbers or in general "pure data" to components, you can also pass other components (or component-constructing functions) into components that then act as partial views or templates.

{{< alert icon="👉" >}}
Hey - are **you** reading this? You can improve this Vide doc you are just reading by forking it and provide a good example for templates and slots :)
{{< /alert >}}
