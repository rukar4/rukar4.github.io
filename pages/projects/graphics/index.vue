<script setup>
const projects = [
  {
    title: 'Ray Tracer',
    description: `A ray tracer command line app that takes in a file and generates a PPM image.`,
    highlights: [
      'Created a simple parser to read .txt files and generate ray traced images.',
      'Calculated the view-port and pixel locations to shoot rays through.',
      'Allows for custom camera positions and angles to view a scene.',
      'Used recursive rays to determine reflection and shadow.',
      'Applied the Phong shading model for color and lighting.',
      'Used an optimized geometric algorithm to calculate color and lighting of certain pixels.',
      'Implemented abstract class for props, allowing easy implementation for different shapes.',
    ],
    image: '/images/ray-tracer-scene-6.jpg',
    github: 'https://github.com/rukar4/RayTracer',
    stack: ['C#', '.NET']
  },
  {
    title: 'Croaklahoma (Video Game)',
    description: `A basic 3D platformer where the player can move around, pick up items, and interact with NPCs.`,
    highlights: [
      'Implemented custom mechanics including camera movement, interaction with objects, and player controls.',
      'Created a custom blob shadow that allows the player to easily determine where their character will land.',
      'Designed a custom 3D model for the player, including UV texturing.',
      'Developed a simple level for the player to explore, including NPCs and items.',
    ],
    video: '/videos/Merrell_Croaklahoma.mp4',
    scripts: '/projects/graphics/croaklahoma',
    stack: ['Godot', 'C#', 'Maya'],
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
    label: 'Full Stack',
    icon: '/icons/layers.svg',
    url: '/projects/full_stack'
  },
  {
    label: 'Artificial Intelligence',
    icon: '/icons/bot.svg',
    url: '/projects/ai'
  }
]
</script>

<template>
  <h1 class="center-container">
    Computer Graphics Projects
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
      :video="project.video"
      :scripts="project.scripts"
      :flipped="project.flipped"
  />
  <IconBanner :links="iconLinks"/>
</template>

<style scoped>

</style>