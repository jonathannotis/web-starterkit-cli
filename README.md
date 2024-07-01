# Web Starterkit Cli

## Install

```
brew install webstarter
```

## Usage

```
webstarter <frontend> <backend> <appname> [options]
```

## **Options**

```
Parameters:
  <frontend>                  Frontend framework/library
  <backend>                   Backend framework/language
  <appname>                   Name of the application

Options:
  -p <dependencies>           Comma-separated list of additional dependencies
                              (e.g., -p axios,redux)
  -P <devDependencies>        Comma-separated list of additional dev dependencies
                              (e.g., -P eslint,prettier)
  -d <database>               Database to use (mongodb, mysql, or sqlite)
  --typescript                Use TypeScript instead of JavaScript
  --yarn                      Use Yarn as the package manager instead of npm
  -h, --help                  Show this help message and exit
```

## **Frontend Options**

- _All frontend web frameworks that use CSS based styles have SASS configured by default_
- [`angluar`](https://angular.io/)
  - **Note:** Typescript is required, not optional
- [`flutter`](https://flutter.dev/)
- [`react`](https://reactjs.org/)
- [`next`](https://nextjs.org/)
- [`svelte`](https://kit.svelte.dev/)
- [`vue`](https://vuejs.org/)

## **Backend Options**

### REST Frameworks:

- [`django`](https://www.djangoproject.com/)
- [`express`](https://expressjs.com/)
- [`flask`](https://flask.palletsprojects.com/)
- [`rails`](https://rubyonrails.org/)

### Databases:

- **Note:** Databases are not created with this command, the REST frameworks are configured with the databases
- [`mongodb`](https://www.mongodb.com/)
- [`mysql`](https://www.mysql.com/)
  - **Note:** MySql is not yet supported for Flask
- [`sqlite`](https://www.sqlite.org/index.html) _(default)_

## **Other Options**

- Use `--yarn` to create your project with yarn, otherwise npm will be the default
- Dependencies and devDependencies applies to only frontend frameworks
