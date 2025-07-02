<script setup>
import Banner from "~/components/Banner.vue";
</script>

<template>
  <h1 class="title center-container">
    Reid Merrell
  </h1>
  <h2 class="center-container">
    Welcome to my portfolio! Explore my projects and learn more about me.
  </h2>
  <hr>
  <div class="info-banner grid-container" style="background-image: url('/byu-campus.jpg');">
    <div class="pfp-card">
      <h3>Reid Merrell</h3>
      <p>Computer Science Student at BYU</p>
      <p>AI and Graphics Enthusiast</p>
    </div>
    <div class="about-me">
      <h3>About Me</h3>
      <p>
        I am a Computer Science student at Brigham Young University with a passion for artificial intelligence and computer graphics.
        I enjoy building projects that combine these fields to create innovative solutions.
      </p>
      <p>
        In my free time, I love exploring new technologies, contributing to open-source projects, and learning about the latest advancements in AI and graphics.
      </p>
    </div>
  </div>
  <div class="center-container">

  </div>
</template>

<style>
.grid-container {
  display: grid;
  grid-template-columns: repeat(12, 1fr);
  gap: 1rem;
}

.pfp-card {
  grid-column: span 4;
  background-color: white;
  background-size: cover;
  border-radius: 8px;
  padding: 1rem;
  color: black;
}

.about-me {
  grid-column: span 8;
  padding: 1rem;
  background-color: white;
  border-radius: 8px;
  color: black;
}
</style>