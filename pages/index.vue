<script setup>
definePageMeta({
  layout: ''
})

let flipped = ref(false)

const projects = [
  {
    title: 'Duckiebot',
    date: 'Sept 2025 - Dec 2025',
    description: `A differential drive robot that uses computer vision to navigate a city, avoid obstacles and recognize
        signs to perform traffic functions.`,
    highlights: [
        'Created ROS (Robotics Operating System) nodes to handle image processing, control, and navigation.',
        'Calibrated camera to account for distortion and improve image processing accuracy.',
        'Used odometry to track the robot\'s position and orientation.',
    ],
    image: '/images/duckietown.jpg',
    mediaNote: 'Video coming soon!',
    stack: ['ROS', 'Docker', 'Python']
  },
  {
    title: 'Maze Solving Robot',
    date: 'Nov 2024 - Dec 2024',
    description: `A program to simulate Bayes filtering for a maze-solving robot using Java.`,
    highlights: [
      'Implemented Bayes filtering to localize the robot, including the sensor and probability models.',
      'Allowed robot to solve mazes with varying sizes, sensor noise, and movement uncertainty.',
      'Tuned value iteration to entice the robot to progress to the goal while avoiding obstacles.',
      'Used an epsilon-greedy algorithm to encourage exploration at the start.'
    ],
    video: '/videos/localizing-robot.mp4',
    mediaNote: `The robot has four sensors to detect walls in each of the cardinal directions.
        The display shows where the robot actually is vs where the robot believes it is. The robot\'s belief is shown
        as a heatmap of probabilities. The darker the blue, the more likely the robot is in that cell.
        The robot attempts to navigate to the goal (green square) while avoiding obstacles (red squares).`,
    github: 'https://github.com/rukar4/BayesFiltering',
    stack: ['Java']
  },
  {
    title: 'Ray Tracer',
    date: 'Jan 2025 - Jul 2025',
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
    stack: ['C#', '.NET'],
    mediaNote: 'Ray traced image sample'
  },
  {
    title: 'Movie Search App',
    date: 'Jul 2025',
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
    date: 'Aug 2023 - Dec 2023',
    description: 'A chess game server that can host multiple games with a terminal client and back-end API.',
    highlights: [
      'Implemented all chess rules and game logic in Java',
      'Built a terminal client for real-time interaction',
      'Designed a database for game management',
      'Implemented communication between client and server using sockets',
      'Created DAOs for database operations',
    ],
    image: '/images/chess-snapshot.jpg',
    github: 'https://github.com/rukar4/ChessGame',
    stack: ['Java', 'MySQL']
  }
]
</script>

<template>
  <h1 class="banner center-container">
    Reid Merrell
  </h1>
  <hr>
  <h2 class="center-container">
    Welcome to my portfolio!
  </h2>

  <div class="info-banner">
    <div class="about-me">
      <h2>About Me</h2>
      <p>
        Hello! I am Reid Merrell, a computer science undergrad at Brigham Young University. Technology has always been
        fascinating to me, and I entered my college career with a desire to learn more about it. Shortly into my college
        career, I discovered my love for software development and algorithm design and eagerly pursued computer science
        for its emphasis in mathematics and programming. After a few bumps along the way, I am now a short few months
        away from graduating with my Bachelor's degree in Computer Science. I am excited to enter the industry, and look
        forward to the opportunities that await me!
      </p>
      <p>
        Outside of school, you can find me and my wife exploring Provo, hiking in the mountains, or binge watching our
        favorite series. I am also dipping my toes into game-dev with a group of friends to create a top-down,
        role-playing game.
      </p>
    </div>
    <div class="media pfp-card">
      <div class="media-clip">
        <img src="/images/pfp-square.jpg" alt="Reid Merrell">
      </div>
    </div>
  </div>

  <hr>
  <h2 class="center-container">
    Explore My Projects
  </h2>

  <ProjectCard
      v-for="(project, index) in projects"
      :key="project.title"
      :title="project.title"
      :date="project.date"
      :description="project.description"
      :highlights="project.highlights"
      :stack="project.stack"
      :image="project.image"
      :video="project.video"
      :media-note="project.mediaNote"
      :github="project.github"
      :demo="project.demo"
      :flipped="index % 2 === 1"
  />

  <ScrollUpBtn/>

  <footer>
    <hr>
    <p>
      Connect with me on
      <a href="https://www.linkedin.com/in/reid-merrell-ai-graphics-developer/"
         target="_blank" rel="noopener noreferrer">LinkedIn</a>
    </p>
    <p>Powered by
      <a href="https://nuxt.com/" target="_blank" rel="noopener noreferrer">Nuxt</a>
    </p>
    <p>Reid Merrell 2025</p>
  </footer>
</template>

<style>
.about-me {
  width: 60%;
  align-content: center;
}

.pfp-card {
  width: 40%;
  padding-left: 2rem;
}

@media (max-width: 1500px) {
  .pfp-card {
    width: 60%;
    padding: 0;
  }

  .about-me {
    width: 90%;
    text-align: left;
  }
}
</style>