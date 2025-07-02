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
        Full Stack
      </NuxtLink>
    </div>
    <div>
      <NuxtLink to="/projects/ai">
        Artificial Intelligence
      </NuxtLink>
    </div>
    <div>
      <NuxtLink to="/projects/graphics">
        Computer Graphics
      </NuxtLink>
    </div>
  </div>
  <hr>
</template>

<style scoped>
div {
  font-size: 1.3rem;
  padding: 1rem;
}

.banner {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 1rem 0;
  box-sizing: border-box;
  min-height: 15vh;
}

@media (max-width: 768px) {
  .banner {
    flex-direction: column;
    align-items: center;
  }

  h1 {
    text-align: center;
    margin-bottom: 1rem;
  }

  div {
    margin: 0.5rem 0;
    text-align: center;
  }
}
</style>