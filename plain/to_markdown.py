import codecs

files = ["access.txt", "business.txt", "cryptography.txt", "deserialization.txt", "logging.txt", "protocol.txt", "validation.txt",
"authentication.txt",  "communication.txt",  "data.txt", "files.txt", "malicious_code.txt"]
folder = "./"

markdown_output_file_name = "generated.md"

def read_file(file_path):
    with codecs.open(file_path, "r", "utf-8") as file:
        return file.readlines()

def get_file_path(file_name):
    return folder + file_name

def file_to_markdown_table(file_name):
    return to_markdown_table(read_file(get_file_path(file_name)))

def to_markdown_table(content):
    lines = []
    for content_line in content:
        lines.append("| " + content_line.replace("\r\n", "") + " |")
    return "\n".join(lines)

def build_header():
    return "| Issue |\n| ------------- |\n"

def files_to_markdown():
    markdown_content = []
    for file_name in files:
        markdown_content.append(file_to_markdown_table(file_name))

    write_markdown(build_header() + "".join(markdown_content))

def write_markdown(content):
    with codecs.open(markdown_output_file_name, "w", "utf-8") as file:
        file.write(content)

files_to_markdown()