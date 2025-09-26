<script setup>
const scripts = [
  {
    title: 'AStarNode Class',
    description: 'Defines a node in the A* pathfinding algorithm, including cost and heuristic information.',
    filename: 'a_star_scripts/AStarNode.cs',
    language: 'csharp'
  },
  {
    title: 'AStarPath Class',
    description: 'Handles the A* pathfinding logic, including tracking the fringe nodes and computing the path.',
    filename: 'a_star_scripts/AStarPath.cs',
    language: 'csharp'
  },
  {
    title: 'LinkAi Class',
    description: 'Agent that uses the A* algorithm to follow the player.',
    filename: 'a_star_scripts/LinkAi.cs',
    language: 'csharp'
  }
]
</script>

<template>
  <h1 class="center-container">
    Unity A* Pathfinding Implementation
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