
> Lucas Magno Zimmer

# Projects

## API

### TaskController

#### **Perform**

`GET /api/task/perform`

Response:
```json
{
    "id": guid,
    "operation": string,
    "left": number,
    "right": number,
    "result": number
}
```

### TaskService

#### **GetTaskFromAPI**

Parameters: None

Returns: `Task<TaskDTO>`

> Calls the tasks API using HttpClient to GET a new task.

#### **PostTaskToAPI**

Parameters: `TaskDTO`

Returns: `Task<string>`

> Calls the tasks API using HttpClient to POST the task and its result.

#### **DoTask**

Parameters: `TaskDTO`

Returns: `TaskDTO`

> Gets the `Func` for the matching `OperationType` and calculates the result, then returns the updated task object.

## API.Tests

### TaskControllerTest
> Empty, no tests implemented.

### TaskServiceTests

#### **GetTaskFromAPI_Should_ReturnTask**

> Not implemented.

#### **Basic operations tests**
- DoTask_Should_PerformAdditionOperation
- DoTask_Should_PerformSubtractionOperation
- DoTask_Should_PerformMultiplicationOperation
- DoTask_Should_PerformDivisionOperation
- DoTask_Should_PerformRemainderOperation


# Challenges

## Flow Control and Enumerations

The first challenge I faced was how to implement the flow of operations. I could use a simple class with consts and the names of the operations in conjunction with a switch, but that seemed too verbose. After all, I'd need a case for each operation.
Then I remembered about the enumeration class concept I read once and decided to try it out, but ended up with the same problem as to how control the flow. Fortunately, it has a method to get an enumeration based on it's name, so I added a property to store a Func for the operation and use it to perform the calculation.

## Result types

What fried my brain the most was the fact that the values used in the operations are humongous, almost at the limit of `long`, and operations such as multiplication cause an overflow. To fix that, I tried using `BigInteger`, but then division would no longer work, because it does not have floating point. And then I got to the real problem: how would I deal with such gigantic numbers **and** different return types? To me, the ideal would be to use some sort of class with generics, but that would required more time, so there were two options left (that I could think of): `dynamic` or `object`.
In the end, I opted to using `object` as return type and everything worked.

# (Technical) Debt

## BigInteger Serialization

When stringfying BigIntegers in C# (e.g. `.ToString()`), it results in the value itself as a string but, for some reason, when serializing, `System.Text.Json` returns the structure of the object without even including the actual value stored. This would require the implementation of a custom converter.

Fiddle example: https://dotnetfiddle.net/QckmQj

## Custom Exception Handling

The mechanism implemented to handle exceptions, internal or from errors from the task API, could be improved upon with more try/catches and more exception types.