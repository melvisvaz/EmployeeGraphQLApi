# Employee GraphQL API

Run the project and open one of these endpoints in Banana Cake Pop or the built-in GraphQL UI:

- http://localhost:5055/graphql
- https://localhost:7245/graphql

## Sample query

```graphql
query {
  employees {
    id
    firstName
    lastName
    email
    department
    salary
  }

  searchEmployees(name: "ali", department: "Engineering") {
    id
    firstName
    lastName
    department
    salary
  }
}
```

The `searchEmployees` query lets you filter employees by name and department.