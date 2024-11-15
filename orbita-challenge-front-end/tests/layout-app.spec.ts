import { mount } from '@vue/test-utils'
import { expect, describe, it } from 'vitest'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'
import LayoutApp from '@/pages/_layouts/app.vue'

const vuetify = createVuetify({
  components,
  directives,
})

global.ResizeObserver = require('resize-observer-polyfill')

describe('LayoutApp.vue', () => {
  it('should display "Módulo Acadêmico" in the app bar title', () => {
    const wrapper = mount({
      template: '<v-layout><layout-app></layout-app></v-layout>'
    }, {
      props: {},
      global: {
        components: {
          LayoutApp,
        },
        plugins: [vuetify],
      }
    })

    expect(wrapper.text()).toContain('Módulo Acadêmico')
  })

  it('should display "Alunos" in the sidebar', () => {
    const wrapper = mount({
      template: '<v-layout><layout-app></layout-app></v-layout>'
    }, {
      global: {
        components: {
          LayoutApp,
        },
        plugins: [vuetify],
      }
    })

    const sidebarItem = wrapper.find('.v-list')

    expect(sidebarItem.exists()).toBe(true)
    expect(sidebarItem.text()).toContain('Alunos')
  })
})
