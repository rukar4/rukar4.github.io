<script setup>
defineProps({
  title: String,
  description: String,
  highlights: Array,
  stack: Array,
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
  <div :class="['info-banner', { flipped }]">
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
      <p v-if="stack" class="stack"><strong>Tech Stack:</strong> {{ stack.join(', ') }}</p>
    </div>
    <div class="media">
      <img v-if="image" :src="image" alt="Project Image" />
      <video v-else-if="video" :src="video" controls />
    </div>
  </div>
</template>

<style scoped>

.info-banner.flipped {
  flex-direction: row-reverse;
}

.media img,
.media video {
  max-height: 100%;
  max-width: 100%;
  border-radius: 8px;
}

.media {
  display: flex;
  justify-content: center;
  width: 40%;
  max-height: 40vh;
}

.content {
  padding: 1rem;
}

.stack {
  padding-top: 0.5rem;
}

.links a {
  margin-right: 1rem;
  text-decoration: underline;
}
</style>