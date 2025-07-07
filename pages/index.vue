<script setup>
// import { definePageMeta } from "nuxt/dist/pages/runtime/index.js";

import Full_stack from "~/pages/projects/full_stack.vue";

definePageMeta({
  layout: 'custom'
})
</script>

<template>
  <h1 class="center-container">
    Reid Merrell
  </h1>
  <hr>
    <h2 class="center-container">
      Welcome to my portfolio!
    </h2>
    <div class="center-container">
      <p>
        Feel free to explore my projects below, or reach out to me directly on
        <a href="https://www.linkedin.com/in/reid-merrell-ai-graphics-developer/"
           target="_blank" rel="noopener noreferrer">LinkedIn</a>!
      </p>
    </div>

  <div class="link-banner">
    <NuxtLink to="/projects/full_stack" class="link-item">
      <div class="icon" style="background-image: url('/layers.svg')"/>
      <div class="label">Full Stack</div>
    </NuxtLink>

    <NuxtLink to="/projects/ai" class="link-item">
      <div class="icon" style="background-image: url('/bot.svg')"/>
      <div class="label">Artificial Intelligence</div>
    </NuxtLink>

    <NuxtLink to="/projects/graphics" class="link-item">
      <div class="icon" style="background-image: url('/file-image.svg')"/>
      <div class="label">Computer Graphics</div>
    </NuxtLink>
  </div>



  <div class="info-card has-overlay" style="background-image: url('/byu-campus.jpg');">
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
        favorite series. I am also working with a group of friends to develop a top-down role-playing game, which has
        been an incredibly challenging, yet exciting, project. Otherwise, you can catch me preparing storylines and
        plots for a novel I am writing or for table-top role-playing games.
      </p>
    </div>
    <div class="pfp-card">
      <h3>Reid Merrell</h3>
      <p>Computer Science Student at BYU</p>
      <p>AI and Graphics Enthusiast</p>
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
h1 {
  padding: 2rem;
}

.link-banner {
  display: flex;
  justify-content: space-around;
  background-color: var(--primary);
  border-radius: 12px;
  padding: 3rem;
  margin: 4rem 2rem 2rem;
  position: relative;
  text-align: center;
}

.link-item {
  flex: 1;
  position: relative;
  display: flex;
  flex-direction: column;
  align-items: center;
  text-decoration: none;
}

.icon {
  position: absolute;
  top: -5rem;
  width: 5rem;
  height: 5rem;
  background: var(--secondary);
  background-size: 70%;
  background-position: center;
  background-repeat: no-repeat;
  border-radius: 50%;
  padding: 0.5rem;
  box-shadow: 0 2px 6px rgba(0, 0, 0, 0.3);
  transition: transform 0.3s ease, box-shadow 0.3s ease;
}

.link-item:hover .icon {
  transform: translateY(-5px);
  box-shadow: 0 4px 10px rgba(0, 191, 255, 0.6);
}

.label {
  margin-top: 2rem; /* space for icon above */
  font-weight: bold;
  text-decoration: none;
}

.pfp-card {
  min-width: 200px;
  align-self: start;
  aspect-ratio: 2 / 3;
  background-color: white;
  border-radius: 8px;
  padding: 1rem;
  margin: 1rem;
  color: #001f2e;
}

.about-me {
  //padding-left: 2rem;
}

@media (max-width: 768px) {
  .pfp-card {
    min-height: 120px;
    min-width: auto;
    align-self: auto;
  }

  .about-me {
    width: 90%;
  }

  .link-banner {
    flex-direction: column;
    align-items: center;
    gap: 2rem;
  }

  .icon {
    position: relative;
    width: 4rem;
    height: 4rem;
    top: 0;
  }

  .label {
    margin-top: 0.5rem;
  }
}
</style>