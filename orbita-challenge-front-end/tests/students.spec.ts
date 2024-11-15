import { mount } from '@vue/test-utils'
import Students from '@/pages/app/student/students.vue'
import { expect, describe, it, beforeEach } from 'vitest'
import { createVuetify } from 'vuetify'
import { nextTick } from 'vue'

describe('Students.vue', () => {
  let wrapper: any

  beforeEach(() => {
    wrapper = mount(Students, {
      global: {
        plugins: [createVuetify()],
      },
    })
  })

  it('should render the table correctly', async () => {
    const studentsMock = [
      { ra: '123', name: 'John Doe', cpf: '123.456.789-00' },
      { ra: '124', name: 'Jane Doe', cpf: '987.654.321-00' },
    ]
    
    wrapper.vm.students = studentsMock
    await nextTick() 

    const rows = wrapper.findAll('tbody tr')

    expect(rows).toHaveLength(studentsMock.length)

    const firstRow = rows.at(0)
    expect(firstRow.text()).toContain('John Doe')
    expect(firstRow.text()).toContain('123.456.789-00')
  })
})
