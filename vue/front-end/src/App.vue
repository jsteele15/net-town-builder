<script setup>
import { ref, onMounted } from "vue";

import Player from "./core/player.vue";

const message = ref("");
const count = ref(0);
const scoreFromServer = ref(0);
onMounted(async () => {
  const res = await fetch("http://localhost:5096/api/message");
  const data = await res.json();
  message.value = data.text;
});

function increase(){
  count.value++
};

async function sendScore(value){
  const res = await fetch("http://localhost:5096/api/score",{
    method: "POST",
    headers: { "Content-Type": "application/json"},
    body: JSON.stringify({ value })
  });
  const data = await res.json();
  scoreFromServer.value = data.total;
}

</script>

<template>
  <Player/>
  <p>{{ message }}</p>
  <p>Server score: {{ scoreFromServer }}</p>
  <button @click="sendScore(count.value)">click me</button>
</template>

<style scoped>
header {
  line-height: 1.5;
}

.logo {
  display: block;
  margin: 0 auto 2rem;
}

@media (min-width: 1024px) {
  header {
    display: flex;
    place-items: center;
    padding-right: calc(var(--section-gap) / 2);
  }

  .logo {
    margin: 0 2rem 0 0;
  }

  header .wrapper {
    display: flex;
    place-items: flex-start;
    flex-wrap: wrap;
  }
}
</style>
