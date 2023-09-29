
files = ["access.txt", "business.txt", "cryptography.txt", "deserialization.txt", "logging.txt", "protocol.txt", "validation.txt",
"authentication.txt",  "communication.txt",  "data.txt", "files.txt", "malicious_code.txt"]
folder = "./"

def read_file(file_path):
    with open(file_path) as file:
        return [line.rstrip('\n') for line in file]

def get_file_path(file_name):
    return folder + file_name

def file_to_markdown_table(file_name):
    return to_markdown_table(read_file(get_file_path(file_name)))

def to_markdown_table(content):
    lines = []
    for content_line in content:
        lines.append("| " + content_line + " |")
    return "\n".join(lines)

def build_header():
    return "| Issue |\n| ------------- |\n"

markdown_content = []

for file_name in files:
    markdown_content.append(build_header() + file_to_markdown_table(file_name))

