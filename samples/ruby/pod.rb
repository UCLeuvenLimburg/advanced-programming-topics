def define_pod(*fields)
    Class.new do
        define_method :initialize do |*args|
            fields.zip(args).each do |field, value|
                instance_variable_set "@#{field}", value
            end
        end

        fields.each do |field|
            define_method field do
                instance_variable_get "@#{field}"
            end
        end

        define_method :inspect do
            str = fields.map do |field|
                value = instance_variable_get "@#{field}"
                "#{field}=#{value}"
            end.join(",")

            "[#{str}]"
        end
    end
end


Person = define_pod :name, :age

person = Person.new("John", 18)
p person
