# Write your code here

def count_odd(ns)
    ns.count(&:odd?)
end




# Testing code

$tests = []

class TestFailed < StandardError
end

def run_tests
    $tests.each(&:run_tests)
end

class Tests
    def read
        while (line = @in.gets).start_with? '#'
        end

        line.chomp
    end

    def read_bool
        read == 'true'
    end

    def read_strings
        n = read.to_i
        (1..n).map { read }
    end

    def assert_equal(expected, actual)
        if expected != actual
            raise TestFailed, "Expected #{expected}, received #{actual}"
        end
    end

    def run_tests
        puts "Running tests for #{tested_function}"

        open(filename) do |input|
            @in = input

            while (line = read) == 'testcase'
                perform_test
            end
        end
    end

    def self.inherited(subclass)
        $tests << subclass.new
    end
end


class CountOddTests < Tests
    def tested_function
        'count_odd'
    end

    def filename
        'count-odd.txt'
    end

    def perform_test()
        ns = read_strings.map(&:to_i)
        expected = read.to_i

        begin
            assert_equal(expected, count_odd(ns))
            puts "PASS"
        rescue StandardError => e
            puts <<~END
            FAILURE
            ns: #{ns}
            Expected: #{expected}
            Error: #{e.message}
            END
        end
    end
end


run_tests()