<template>
  <div class="main-content">
    <h1>Ovo je brojač</h1>
    <div class="counter">{{ counter }}</div>
    <button v-on:click="increaseCounter">Povećaj me</button>
  </div>
</template>

<script>
export default {
  name: 'HelloWorld',
  data() {
    return {
      counter: 0,
      urlBase: 'https://internshipwebapicounter.azurewebsites.net/api'
    };
  },
  created: function() {
    this.$axios.get(`${this.urlBase}/counter/get-counter`).then(response => {
      this.counter = response.data;
    });

    let that = this;
    setInterval(function() {
      that.$axios.get(`${that.urlBase}/counter/get-counter`).then(response => {
        that.counter = response.data;
      });
    }, 1000);
  },
  methods: {
    increaseCounter: function() {
      this.$axios
      .post(`${this.urlBase}/counter/increase-counter`, {})
      .then(() => {
        this.counter++;
      })
      .catch(() => {
        alert('Povećanje nije uspjelo!');
      });
    }
  }
}
</script>

<style scoped>
.main-content {
  display: flex;
  flex-direction: column;
  align-items: center;
}

h1 {
  font-size: 28px;
  font-weight: 700;
  margin-bottom: 28px;
}

.counter {
  font-size: 18px;
}

button {
  outline: none;
  border: none;
  padding: 6px 4px;
  background-color: #30cec1;
  color: white;
  cursor: pointer;
  width: 80px;
  border-radius: 4px;
  margin-top: 12px;
}
</style>
