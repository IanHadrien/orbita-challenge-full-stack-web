/** @type {import('tailwindcss').Config} */
module.exports = {
  // darkMode: ["class"],
  content: [
    "./index.html",
    "./src/**/*.{vue,js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      colors: {
        black: '#2D2C2C',
        darkGreen: '#00A0A6'
      }
    },
  },
  plugins: [],
}

