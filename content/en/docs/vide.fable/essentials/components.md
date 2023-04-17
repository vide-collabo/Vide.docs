---
title: "Components"
description: "Components"
lead: ""
date: 2020-10-13T15:21:01+02:00
lastmod: 2020-10-13T15:21:01+02:00
draft: false
images: []
weight: 500
toc: true
---

As an extension to the previous counter, cats 🐈 and dogs 🐕 shall be counted. Here is a first approach:

```fsharp
vide {
    // cat counter
    div {
        let! count = Vide.ofMutable 0

        button
            .onclick(fun _ -> count.Value <- count.Value + 1) {
            "Count cats!"
        }
        $"cats: {count.Value}"
    }

    // dog counter
    div {
        let! count = Vide.ofMutable 0

        button
            .onclick(fun _ -> count.Value <- count.Value + 1) {
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
        let! count = Vide.ofMutable 0

        button
            .onclick(fun _ -> count.Value <- count.Value + 1) {
            $"Count %s{elementName}!"
        }
        $"{elementName}: {count.Value}"
    }
}
```

{{< alert icon="👉" >}}
An F# side note: The **elementName** is constrained to be of type **string** via the **%s** type annotation at the first usage in the interpolated string. It could have been left unconstrained or directly at the function parameter.
{{< /alert >}}


The component can be used like any other HTML element in the final view:

```fsharp
vide {
    counter "cats"
    counter "dogs"
}
```
