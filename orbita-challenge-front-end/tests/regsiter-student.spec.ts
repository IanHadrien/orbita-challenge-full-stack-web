import { mount } from '@vue/test-utils'
import RegisterStudent from '@/pages/app/student/register-student.vue'
import { expect, describe, it, beforeEach } from 'vitest'
import { createVuetify } from 'vuetify'

describe('RegisterStudent.vue', () => {
  let wrapper: any

  beforeEach(() => {
    wrapper = mount(RegisterStudent, {
      global: {
        plugins: [createVuetify()],
      },
    })
  })

  it('should render the registration button', () => {
    const registerButton = wrapper.find('button')
    expect(registerButton.exists()).toBe(true)
  })
})
