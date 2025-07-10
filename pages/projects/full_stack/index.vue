<script setup>
const projects = [
  {
    title: 'Movie Search App',
    description: 'A simple movie search application designed to return the most popular movies based on a query.',
    highlights: [
      'Implemented client-server communication using Express.js and Axios',
      'Communicated with third party API to retrieve movie details (TMDB)',
      'Deployed server using Render for live demo',
      'Used custom CSS for a responsive and modern design',
    ],
    image: '/images/movie-snapshot.png',
    github: 'https://github.com/rukar4/Movie',
    demo: 'https://rukar4.github.io/Movie/',
    stack: ['Nuxt 3', 'CSS', 'Render']
  },
  {
    title: 'Chess Game',
    description: 'A chess game server that can host multiple games with a terminal client and back-end API.',
    highlights: [
      'Implemented all chess rules and game logic in Java',
      'Built a terminal client for real-time interaction',
      'Designed a database for game management',
      'Implemented communication between client and server using sockets',
      'Created DAOs for database operations',
    ],
    image: '/icons/crown.svg',
    github: 'https://github.com/rukar4/ChessGame',
    stack: ['Java', 'MySQL'],
    flipped: true
  }
]

const iconLinks = [
  {
    label: 'Home',
    icon: '/icons/house.svg',
    url: '/'
  },
  {
    label: 'Artificial Intelligence',
    icon: '/icons/bot.svg',
    url: '/projects/ai'
  },
  {
    label: 'Computer Graphics',
    icon: '/icons/file-image.svg',
    url: '/projects/graphics'
  }
]
</script>

<template>
  <h1 class="center-container">
    Full Stack Projects
  </h1>
  <ProjectCard
      v-for="project in projects"
      :key="project.title"
      :title="project.title"
      :description="project.description"
      :highlights="project.highlights"
      :stack="project.stack"
      :image="project.image"
      :github="project.github"
      :demo="project.demo"
      :flipped="project.flipped"
  />
  <IconBanner :links="iconLinks" />

</template>

<style scoped>

</style>