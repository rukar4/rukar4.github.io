# Portfolio

This is a portfolio of my work as a software developer. It includes various projects that showcase my skills in 
different computer science domains. There are three main categories of projects: full stack development, artificial 
intelligence, and computer graphics.

This site was developed using Vue.js and custom CSS. It is hosted on GitHub Pages by generating and deploying the static
files using GitHub Actions.

## Deployment
Run `npm run deploy` to build the project and deploy it to GitHub Pages. This command generates the static files and 
automatically adds the `.nojekyll` file to the root directory to prevent Jekyll from processing the site. Then, it 
deploys the static files to the `gh-pages` branch of the repository.

## Local Development
To run the project locally, use the following commands:
```bash
npm install
npm run dev
```

This will run the site on `http://localhost:3000` by default.