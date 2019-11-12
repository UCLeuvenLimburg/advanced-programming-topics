class Module
    def getter(field)
        method_name = "get_#{field}".to_sym

        define_method(method_name) do
            instance_variable_get "@#{field}"
        end
    end

    def setter(field)
        method_name = "set_#{field}".to_sym

        define_method(method_name) do |value|
            instance_variable_set("@#{field}", value)
        end
    end
end


class Person
    def initialize(name)
        @name = name
    end

    # adds a method "get_name" that returns the value of the @name field
    # (in Ruby, fields must start with a @)
    getter :name

    # adds a method "set_name" that sets the @name field
    setter :name
end


person = Person.new "John"
puts person.get_name

person.set_name "Peter"
puts person.get_name
