<script setup>
const projects = [
  {
    title: 'Maze Solving Robot',
    description: `A program to simulate Bayes filtering for a maze-solving robot using Java.
        The robot has four sensors to detect walls in each of the cardinal directions.
        The display shows where the robot actually is vs where the robot believes it is. The robot\'s belief is shown
        as a heatmap of probabilities. The darker the blue, the more likely the robot is in that cell.
        The robot attempts to navigate to the goal (green square) while avoiding obstacles (red squares).`,
    highlights: [
      'Implemented Bayes filtering to localize the robot, including the sensor and probability models.',
      'Allowed robot to solve mazes with varying sizes, sensor noise, and movement uncertainty.',
      'Tuned value iteration to entice the robot to progress to the goal while avoiding obstacles.',
      'Used an epsilon-greedy algorithm to encourage exploration at the start.'
    ],
    video: '/videos/localizing-robot.mp4',
    github: 'https://github.com/rukar4/BayesFiltering',
    stack: ['Java']
  },
  {
    title: 'A* Pathfinding Script',
    description: `A Unity script to find the shortest path between two points in a grid using the A* algorithm.
        The script can be attached to any GameObject and allows for dynamic pathfinding in a grid-based environment.`,
    highlights: [
      'Implemented the A* algorithm for efficient pathfinding.',
      'Visualizes the pathfinding process in Unity.',
      'Tuned heuristic function to reduce jitters and improve natural movement.',
    ],
    image: '/images/a-star-path.jpg',
    scripts: '/projects/ai/a_star',
    stack: ['Unity', 'C#'],
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
    label: 'Computer Graphics',
    icon: '/icons/file-image.svg',
    url: '/projects/graphics'
  }
]
</script>

<template>
  <h1 class="center-container">
    Artificial Intelligence Projects
  </h1>
  <ProjectCard
      v-for="project in projects"
      :key="project.title"
      :title="project.title"
      :description="project.description"
      :highlights="project.highlights"
      :stack="project.stack"
      :image="project.image"
      :video="project.video"
      :github="project.github"
      :demo="project.demo"
      :scripts="project.scripts"
      :flipped="project.flipped"
  />
  <IconBanner :links="iconLinks"/>
</template>
