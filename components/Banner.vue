<script setup>

</script>

<template>
  <div class="banner">
    <h1>
      <NuxtLink to="/" class="title">
        Reid Merrell
      </NuxtLink>
    </h1>
    <div>
      <NuxtLink to="/projects/full_stack">
        My Full Stack Projects
      </NuxtLink>
      <NuxtLink to="/projects/ai">
        My AI Projects
      </NuxtLink>
      <NuxtLink to="/projects/graphics">
        My Computer Graphics Projects
      </NuxtLink>
    </div>
  </div>
  <hr>
</template>

<style scoped>
.title {
  font-size: 2.5rem;
  color: inherit;
  text-decoration: none;
  cursor: pointer;
}

.title:hover {
  color: inherit;
  text-decoration: none;
}

.banner {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 1rem 0;
  box-sizing: border-box;
  min-height: 10vh;
}
</style>