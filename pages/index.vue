<script setup>

</script>

<template>
<!--  <h1 class="title center-container">-->
<!--    Reid Merrell-->
<!--  </h1>-->
<!--  <h2 class="center-container">-->
<!--    Welcome to my portfolio! Explore my projects and learn more about me.-->
<!--  </h2>-->
<!--  <hr>-->
  <div class="info-card has-overlay" style="background-image: url('/byu-campus.jpg');">
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
        In my free time, I love exploring the outdoors, hiking, and spending time with friends and family.
      </p>
    </div>
  </div>
  <div class="center-container">

  </div>
</template>

<style>
.pfp-card {
  //max-width: 40%;
  min-width: 120px;
  align-self: center;
  aspect-ratio: 2 / 3;
  background-color: white;
  //background-size: cover;
  border-radius: 8px;
  padding: 1rem;
  color: #001f2e;
}

.about-me {
  padding-left: 2rem;
}

@media (max-width: 768px) {
  .pfp-card {
    min-height: 60px;
  }

  .about-me {
    width: 90%;
    padding-left: 0;
  }
}
</style>