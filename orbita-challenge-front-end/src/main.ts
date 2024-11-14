import { registerPlugins } from '@/plugins'
import Toast from 'vue-toastification'

import "vue-toastification/dist/index.css";

// Tailwind Css
import "./styles/style.css"

// Components
import App from './App.vue'

// Composables
import { createApp } from 'vue'

const app = createApp(App)

registerPlugins(app)

app.use(Toast)

app.mount('#app')
