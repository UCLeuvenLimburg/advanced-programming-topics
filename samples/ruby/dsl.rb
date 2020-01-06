class MidiEventContext
    def identifier(id)
        @id = id
    end

    def name(str)
        @name = str
    end

    def field(name, type)
        (@fields ||= []) << [ name, type ]
    end

    def build
        abort "Forgot to define id" unless @id
        abort "Forgot to define name" unless @name
    end
end

def define_midi_event(&block)
    context = MidiEventContext.new
    context.instance_eval(&block)
    context.build
end


define_midi_event do
    name :note_off
    id 0x80
    field :channel, :uint8
    field :note_number, :uint8
end

define_midi_event do
    name :note_on
    id 0x90
    field :channel, :uint8
    field :note_number, :uint8
end
