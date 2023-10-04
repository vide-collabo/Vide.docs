---
title: "Control Flow: if-else"
description: "Control Flow: if-else"
lead: ""
date: 2020-10-13T15:21:01+02:00
lastmod: 2020-10-13T15:21:01+02:00
draft: false
images: []
weight: 500
toc: true
---

Let's extend the counter again: The user's patience shall be rewarded when he counts many items by a well-intentioned message.

```fsharp
vide {
    let! count = ofMutable {0}
    button.onclick(fun _ -> count.Value <- count.Value + 1) {
        $"Count = {count.Value}"
    }

    // TODO: Display the message on every 5th count
    p {
        "...will you go on?"
    }
}
```

## Using 'hidden'

A simple, yet working solution for that is to hide the message conditionally by using the `hidden` attribute, which takes a boolean as argument:

```fsharp
p.hidden(count.Value % 5 <> 0) {
    "...will you go on?"
}
```

## Using 'if'

While using `hidden` is valid for such simple use cases, there's a disadvantage: The hidden element(s) sit always in the DOM, which can lead to performance issues, layout problems, eager loading issues, etc. Working around those issues can lead to new issues, or makes writing and understanding the code harder.

These issues are adressed by using the language-level construct `if` and `else` that actually work on DOM-level:

```fsharp
if count.Value % 5 = 0 then
    p {
        "...will you go on?"
    }
else
    elseForget
```

In this case, the `p` element in only inserted in the DOM when the condition is met, and removed otherwise.

## else: What to do?

The `else`-branch used here with `elseForget` cannot be omitted, because Vide needs to know what to do with state that was eventually built up in the `if` branch. To get a better understanding of what that means, we extend our program by introducing `state in the if-branch`: The user shall be able to check a box wether he/she is "...willing to go on":

## else: Forget

```fsharp
if count.Value % 5 = 0 then
    p {
        "...will you go on?"

        let! isWillingToGoOn = ofMutable {false}
        input
            .type'("checkbox")
            .checked'(isWillingToGoOn.Value)
            .oninput(fun x -> isWillingToGoOn.Value <- x.node.``checked``)
    }
else
    elseForget
```

Now try this: Count to a multiple of 5 and check the checkbox. Count to the next multiple: The checkbox is again unchecked! The reason for this behaviour is caused by the `elseForget` in the `else`-branch. It tells Vide to throw away all the state built up during its previous `if`-branch evaluation. When it then comes to a subsequent `if`-branch evaluation, the content inside the `if`-branch and its local state start from scratch with their initial values.

## else: Preserve

There is another statement useful for `else`-branches: `elsePreserve`, which can be seen as the opposite of `elseForget`: It preserves the state of previous `if`-evaluations until the next `if`-evaluation, thus continuing the program in the `if`:

```fsharp
if count.Value % 5 = 0 then
    (* ... *)
else
    elsePreserve
```

## else: Don't Mix Views

TL;DR: Using `if-else` to switch between 2 view is not recommended. Although this might compile (the types of state used in the `if` and its corresponding `else`-branch have to be identical), it can have a negative impact on performance, and it might lead to "remaining" attribute values on some elements. So please follow this rule:

{{< alert icon="🚨" >}}
There are only 2 valid `else`-expressions: `elseForget` and `elsePreserve`. Never do anything "else" - even if it might compile.
{{< /alert >}}
