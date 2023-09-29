
files = ["access.txt", "business.txt", "cryptography.txt", "deserialization.txt", "logging.txt", "protocol.txt", "validation.txt",
"authentication.txt",  "communication.txt",  "data.txt", "files.txt", "malicious_code.txt"]
folder = "./"

def read_file(file_path):
    with open(file_path) as file:
        return file.read() 

def get_file_path(file_name):
    return folder + file_name

print(read_file(get_file_path(files[0])))