Certainly! Here’s a simplified version of `CONVENTIONS.md` without using backticks:

---

# CONVENTIONS.md

### General

- **Readability:** Write clear code. Use descriptive names.
- **Comments:** Explain why things are done.
- **Error Handling:** Comment on where you leave errors and why.

### Files and Directories

- **Files:** Use PascalCase. Example: MyUser.cs
- **CSS Files:** Match the Razor page name. Example: MainPage.razor.css for MainPage.razor
- **Directories:** Use PascalCase.

### Naming

- **Classes, Methods, Properties:** Use PascalCase. Example: UserService
- **Private Fields:** Use camelCase with an underscore. Example: _userService

### Code Structure

- **Namespaces:** Reflect project structure. Example: ProjectName.Services
- **Usings:** Write the full using on the top of the file.

## MAUI Blazor

### Pages and Components

- **Pages:** Use .razor. Example: MainPage.razor
- **Components:** Use PascalCase. Example: LoginForm.razor

### Data Binding

- **Binding:** Use @bind-. Example: @bind-Value="userName"

### Services

- **Registration:** Use AddSingleton, AddScoped, or AddTransient in Startup.cs or Program.cs

### Razor Syntax

- **Directives:** Place at the top. Example: @page "/home"
- **Markup:** Use proper indentation. Example:

  ```
  @page "/home"

  <div>
      <h1>@Title</h1>
      <p>@Description</p>
  </div>

  @code {
  // code
  }
  ```

### Event Handling

- **Methods:** Use PascalCase. Example: OnSubmit
- **Async:** Use async Task. Example: async Task OnClickAsync() { }

## Code Formatting

- **Indentation:** Use 4 spaces.
- **Line Length:** Keep lins under 120 characters.
- **Braces:** Always use braces. Example:

  if (condition)
  {
  // code
  }
  else
  {
  // code
  }
