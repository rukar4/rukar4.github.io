<script setup>
definePageMeta({
  layout: 'custom'
})

const projectLinks = [
  {
    label: 'Full Stack',
    icon: '/icons/layers.svg',
    url: '/projects/full_stack'
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
    <div class="pfp-card">
    </div>
  </div>

  <div class="info-card has-overlay"
       style="background-image: url('/images/byu-campus.jpg'); justify-content: center; width: 100%;">
    <div style="width: 95%">
      <div class="center-container">
        <div>
          <h2>Explore</h2>
          <p>
            Dive into my projects in full stack development, artificial intelligence, and computer graphics!
          </p>
        </div>
      </div>
      <IconBanner :links="projectLinks"/>
    </div>
  </div>

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
.pfp-card {
  width: 25%;
  aspect-ratio: 1 / 1;
  background-color: white;
  background-image: url('/images/pfp-square.jpg');
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
  border-radius: 8px;
  padding: 1rem;
  margin: 1rem;
  color: #001f2e;
}

.about-me {
  width: 60%;
  align-content: center;
}

@media (max-width: 800px) {
  .pfp-card {
    min-height: 120px;
    min-width: auto;
    align-self: auto;
  }

  .about-me {
    width: 90%;
    text-align: left;
  }
}
</style>