Open https://localhost:{portno}/graphql (Banana Cake Pop / Nitro UI) and try:
Custom search resolver:
graphqlquery {
  searchEmployees(name: "ali", department: "Engineering") {
    id
    firstName
    lastName
    department
    salary
  }
}