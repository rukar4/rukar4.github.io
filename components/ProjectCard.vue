<script setup>
defineProps({
  title: String,
  description: String,
  highlights: Array,
  image: String,
  video: String,
  github: String,
  demo: String,
  flipped: {
    type: Boolean,
    default: false
  }
})
</script>

<template>
  <div :class="['project-card', { flipped }]">
    <div class="media">
      <img v-if="image" :src="image" alt="Project Image" class="project-image" />
      <video v-else-if="video" :src="video" controls />
    </div>
    <div class="content">
      <h2>{{ title }}</h2>
      <p>{{ description }}</p>
      <ul>
        <li v-for="highlight in highlights" :key="highlight">{{ highlight }}</li>
      </ul>
      <div class="links">
        <a v-if="github" :href="github" target="_blank" rel="noopener noreferrer">GitHub</a>
        <a v-if="demo" :href="demo" target="_blank" rel="noopener noreferrer">Live Demo</a>
      </div>
    </div>
  </div>
</template>

<style scoped>
.project-card {
  display: flex;
  gap: 2rem;
  margin-bottom: 3rem;
  align-items: center;
}

.info-banner.flipped {
  flex-direction: row-reverse;
}

.media img,
.media video {
  width: 60%;
  border-radius: 8px;
}

.content {
  padding: 1rem;
}

.links a {
  margin-right: 1rem;
  text-decoration: underline;
}
</style>