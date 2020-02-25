# NswagVersioningSample
## Framework
- netcoreapp2.1
## Package
- "Microsoft.AspNetCore.Mvc.Versioning" Version="2.3.0"
- "Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer" Version="2.2.0"
- "Microsoft.AspNetCore.Razor.Design" Version="2.1.2"
- "NSwag.AspNetCore" Version="13.2.3"
## Use Atribute
- ApiVersion("1")
- Route("api/v{version:apiVersion}/[controller]")
- MapToApiVersion("0")
## Sample
**Select v0**
![2020-02-25_18h08_53](https://user-images.githubusercontent.com/36953431/75232159-1260dd80-57fa-11ea-812b-a390604770be.png)
**Select v1**
![2020-02-25_18h08_59](https://user-images.githubusercontent.com/36953431/75232162-14c33780-57fa-11ea-9c0a-19f97bc577d6.png)
