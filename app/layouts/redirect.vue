<script setup>
</script>

<template>
  <div class="page">
    <header>
      <h1 class="banner center-container">
        <NuxtLink to="/" class="title">
          Reid Merrell
        </NuxtLink>
      </h1>
      <hr>
    </header>

    <main class="center-container">
      <slot/>
    </main>

    <FooterContent/>
  </div>
</template>

<style scoped>
.title {
  color: inherit;
  text-decoration: none;
  cursor: pointer;
}

.title:hover {
  color: inherit;
  text-decoration: none;
}
</style>
