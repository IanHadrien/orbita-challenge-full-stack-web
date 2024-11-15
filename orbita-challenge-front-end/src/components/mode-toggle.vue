<template>
  <div class="mt-1 mr-3">
    <input
      type="checkbox"
      class="checkbox"
      id="checkbox"
      data-testid="checkbox"
      v-model="isDarkMode"
      @change="toggleDarkMode"
    />
    <label
      for="checkbox"
      class="checkbox-label border border-gray-100 bg-gray-100 transition-colors"
    >
      <v-icon color="#f39c12" icon="mdi-white-balance-sunny"/>
      <v-icon color="#f1c40f" icon="mdi-moon-waning-crescent"/>
      <span class="ball bg-gray-900"></span>
    </label>
  </div>
</template>

<script>
  import { useTheme } from 'vuetify'

  export default {
    name: "ToggleDarkMode",

    setup() {
      const theme = useTheme()
      return { theme }
    },

    data() {
      return {
        isDarkMode: localStorage.getItem('theme') === 'dark',
      };
    },

    methods: {
      toggleDarkMode() {
        const newTheme = this.isDarkMode ? 'dark' : 'light' 

        localStorage.setItem('theme', newTheme)

        this.updateVuetifyTheme(newTheme)
      },

      updateThemeFromStorage() {
        this.isDarkMode = localStorage.getItem('theme') === 'dark'

        if (this.isDarkMode) {
          this.theme.global.name.value = 'dark'
        } else {
          this.theme.global.name.value = 'light'
        }
      },

      updateVuetifyTheme(newTheme) {
        this.theme.global.name.value = newTheme
      },
    },

    mounted() {
      this.updateThemeFromStorage()
    },
  }
</script>

<style scoped>
.checkbox {
  opacity: 0;
  position: absolute;
}

.checkbox-label {
  width: 70px;
  height: 38px;
  border-radius: 50px;
  position: relative;
  padding: 6px;
  cursor: pointer;
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.checkbox-label .ball {
  width: 30px;
  height: 30px;
  position: absolute;
  left: 2px;
  top: 4px;
  border-radius: 50%;
  transition: transform 0.2s linear;
}

.checkbox:checked + .checkbox-label .ball {
  transform: translateX(32px);
}

.support {
	position: absolute;
	right: 20px;
	bottom: 20px;
}

.support a {
  color: #292c35;
  font-size: 32px;
  backface-visibility: hidden;
  display: inline-block;
  transition: transform 0.2s ease;
}

.support a:hover{
  transform: scale(1.1);
}
</style>
