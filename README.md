# Web Starterkit Cli

## Install

```
brew [command]
```

## Usage

```
web-starterkit-cli <frontend> <backend> <appname> -p <dependencies> -P <devDependencies> -d <database> --typescript --yarn
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
