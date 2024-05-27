
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG Config=Debug
WORKDIR /src


COPY ["ccse-cw1.csproj", "." ]
COPY ["ccse-cw1.sln", "."] 
COPY . .


RUN dotnet restore "ccse-cw1.csproj"
RUN dotnet publish -c release -r linux-x64 -o /app ccse-cw1.sln 


FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "ccse-cw1.dll"]
