<template>
  <div class="page">
    <header>
      <div class="banner">
        <h1>
          <NuxtLink to="/" class="title">
            Reid Merrell
          </NuxtLink>
        </h1>

        <div class="divider"/>
        <div class="nav-link">
          <NuxtLink to="/projects/full_stack">
            <span/>
            Full Stack
          </NuxtLink>
        </div>

        <div class="divider"/>
        <div class="nav-link">
          <NuxtLink to="/projects/ai">
            <span/>
            Artificial Intelligence
          </NuxtLink>
        </div>

        <div class="divider"/>
        <div class="nav-link">
          <NuxtLink to="/projects/graphics">
            <span/>
            Computer Graphics
          </NuxtLink>
        </div>
      </div>
      <hr>
    </header>

    <main>
      <slot/>
    </main>

    <footer>
      <hr>
      <p>
        Connect with me on
        <a href="https://www.linkedin.com/in/reid-merrell-ai-graphics-developer/">LinkedIn</a>
      </p>
      <p>Powered by Nuxt.js</p>
    </footer>
  </div>
</template>

<style scoped>
.page {
  display: flex;
  flex-direction: column;
  min-height: 100vh;
}

main {
  flex: 1;
}

footer {
  text-align: center;
  padding: 1rem 0;
  margin-top: auto;
}

span {
  position: absolute;
  width: 100%;
  height: 100%;
  top: 0;
  left: 0;

  z-index: 1;
}

.banner {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin: 1rem;
  padding: 1rem 0;
  box-sizing: border-box;
  min-height: 10vh;
}

h1 {
}

.title {
  font-size: 2.5rem;
  color: inherit;
  text-decoration: none;
  cursor: pointer;
  padding-left: 1rem;
}

.title:hover {
  color: inherit;
  text-decoration: none;
}

.nav-link {
  //text-align: center;
  position: relative;
  //height:100%;
  //width: 100%;
  font-size: 1.3rem;
  padding: 1rem;
  cursor: pointer;
  transition: box-shadow 0.3s ease, background-color 0.3s ease;
}

.nav-link :deep(a) {
  display: block;
  width: 100%;
  height: 100%;
  text-decoration: none;
  color: inherit;
  cursor: pointer;
}

.nav-link:hover {
  background-color: rgba(0, 191, 255, 0.1);
  box-shadow: 0 0 10px rgba(0, 191, 255, 0.5);
}

@media (max-width: 768px) {
  .banner {
    flex-direction: column;
    align-items: center;
  }

  .nav-link {
    width: 100%;
    text-align: center;
    padding: 0.5rem 0.5rem;
  }
}
</style>