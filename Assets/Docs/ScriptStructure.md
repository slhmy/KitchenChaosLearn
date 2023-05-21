# Script Structure

When you first get into this document,
all you need to know is,
scripts are the customized way we plant into each component
(which is I think currently the smallest unit of object in Unity).

Component describes an Unity Object in various aspects,
and scripted component controls attributes 
'the object have' | 'provided by other component'.

There are definitely relations between each script,
but basically a rule can be followed is:
<font color="green">
    only read attributes from other component, if there are a related attribute change, use `Update` | `Event`.
</font>