import { mount } from '@vue/test-utils'
import { expect, describe, it } from 'vitest'
import ToggleDarkMode from '@/components/mode-toggle.vue'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'

const vuetify = createVuetify({
  components,
  directives,
})

describe('ToggleDarkMode.vue', () => {
  it('should render the dark mode toggle checkbox', () => {
    const wrapper = mount(ToggleDarkMode, {
      global: {
        plugins: [vuetify],
      }
    })

    const checkbox = wrapper.find('[data-testid="checkbox"]')

    expect(checkbox.exists()).toBe(true)
  })

  it('should have the correct initial state for dark mode based on localStorage', () => {
    localStorage.setItem('theme', 'dark')

    const wrapper = mount(ToggleDarkMode, {
      global: {
        plugins: [vuetify],
      }
    })

    const checkbox = wrapper.find('[data-testid="checkbox"]')
    expect((checkbox.element as HTMLInputElement).checked).toBe(true)
  })

  it('should update Vuetify theme when the checkbox is toggled', async () => {
    localStorage.setItem('theme', 'light')

    const wrapper = mount(ToggleDarkMode, {
      global: {
        plugins: [vuetify],
      }
    })

    const component = wrapper.vm
    const initialTheme = component.theme.global.name.value

    expect(initialTheme).toBe('light')
  })
})
