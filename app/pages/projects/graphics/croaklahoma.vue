<script setup>
const scripts = [
  {
    title: 'Player Class',
    description: 'Handles basic player movement and controls, including interaction with objects and NPCs.',
    filename: 'croaklahoma_scripts/Player.cs',
    language: 'csharp'
  },
  {
    title: 'CameraPivot Class',
    description: `Handles camera controls. Ensures camera stays in view of the player, even when obstacles pass between
      the two.`,
    filename: 'croaklahoma_scripts/CameraPivot.cs',
    language: 'csharp'
  },
  {
    title: 'ShadowCast Class',
    description: 'Casts a blob shadow beneath the player to help the player when aiming their jumps.',
    filename: 'croaklahoma_scripts/ShadowCast.cs',
    language: 'csharp'
  }
]
</script>

<template>
  <h1 class="center-container">
    Croaklahoma Player Control Implementation
  </h1>
  <CodeScript v-for="script in scripts"
              :key="script.filename"
              :title="script.title"
              :description="script.description"
              :filename="script.filename"
              :language="script.language"
  />
</template>

<style scoped>

</style>