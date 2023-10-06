| Issue |
| ------------- |
| It shall be verified that users can only access secured functions or services for which they possess specific authorization. |
| It shall be verified that users can only access secured URLs for which they possess specific authorization. |
| It shall be verified that users can only access secured data files for which they possess specific authorization. |
| It shall be verified that direct object references are protected in a way that ensures only authorized objects are accessible to each user. |
| It shall be verified that directory browsing is disabled unless required. |
| It shall be verified that users can only access protected data for which they possess specific authorization (for example, by implementing controls to protect against direct object reference tampering and prevent unauthorized access to data). |
| It shall be verified that access controls fail securely. |
| It shall be verified that the same access control rules implied by the presentation layer are enforced on the server side for that user role, and that controls and parameters cannot be re-enabled or re-added by users with higher privileges. |
| It shall be verified that all user and data attributes and policy information used by access controls cannot be manipulated by end users unless specifically authorized. |
| It shall be verified that all access controls are enforced on the server side. |
| It shall be verified that all access control decisions can be logged and all failed decisions are logged. |
| It shall be verified that the application or framework generates strong random anti-CSRF tokens unique to the user as part of all high value transactions or accessing protected data, and that the application verifies the presence of such tokens with the proper value for the current user when processing these requests. |
| Aggregate access control protection – It shall be verified that the system can protect against aggregate or continuous access of secured functions, resources, or data, possibly by the use of a resource governor, for example, to limit the number of registrations per hour or to prevent the entire database from being scraped by an individual user. |
| It shall be verified that a centralized mechanism (including libraries that call external authorization services) is in place to control access to each type of protected resource. |
| It shall be verified that there is segregation between privileged logic and other application code. |
| Appropriate access controls shall be implemented for protected data stored on the server. This includes cached data, temporary files and data accessible only by specific system users. |
| It shall be verified that service accounts or accounts supporting connections to or from external systems have the least privilege possible |
| It shall be verified that account auditing is implemented and that unused accounts are disabled (for example, after more than 30 days from the expiration of an account’s password). |
| If long authenticated sessions are allowed, a user’s authorization shall be periodically re-validated to ensure that their privileges have not changed. In case their privileges have changed, the user shall be logged out and forced to re-authenticate. |
| It shall be verified that the application supports disabling of accounts and terminating sessions when authorization ceases (for example, upon changes to role, employment status, business process, etc.). || Application processes and all high value business logic flows shall be verified in a trusted environment, such as on a protected and monitored server. |
| It shall be verified that the application does not allow spoofed high value transactions, such as allowing Attacker User A to process a transaction as Victim User B, by tampering with or replaying session, transaction state, transaction or user IDs. |
| It shall be verified that the application does not allow high value business logic parameters to be tampered with, which include, but are not limited to, price, interest, discounts, PII, balances, stock IDs, etc. |
| It shall be verified that the application has defensive measures; such as verifiable and protected transaction logs, audit trails or system logs, and, in the highest value systems, real time monitoring of user activities and transactions for anomalies; to protect against repudiation attacks. |
| It shall be verified that the application protects against information disclosure attacks, such as direct object reference, tampering, session brute force or other attacks. |
| It shall be verified that the application has sufficient detection and governor controls to protect against brute force (such as the continuous use of a particular function) or denial of service attacks. |
| It shall be verified that the application has sufficient access controls to prevent elevation of privilege attacks. Such controls shall include preventing anonymous users from accessing secured data or secured functions, and preventing users from accessing each other’s details or using privileged functions. |
| It shall be verified that the application processes business logic flows in sequential steps only, with all steps being processed directly. Additionally, the application shall be verified not to process out of order, skip steps, process steps from another user, or process transactions submitted quickly. |
| It shall be verified that the application has additional authorization (such as step up or adaptive authentication) for lower value systems, and/or segregation of duties for high value applications, to enforce anti-fraud controls as per the risk of application and past fraud. |
| It shall be verified that the application has business limits and enforces them in a trusted location (e.g., on a protected server) on a per user or per day basis, with configurable alerting and automated reactions to automated or unusual attack. || It shall be verified that all cryptographic functions used to protect secrets from the application user are implemented on the server side. |
| It shall be verified that all cryptographic modules fail securely. |
| It shall be verified that any master secret(s) is protected from unauthorized access (A master secret is an application credential stored as plaintext on disk that is used to protect access to security configuration information). |
| It shall be verified that all random numbers, random file names, random GUIDs, and random strings are generated using the cryptographic module’s approved random number generator when these random values are intended to be unguessable by an attacker. |
| It shall be verified that cryptographic modules used by the application have been validated as per relevant policies and procedures. |
| It shall be verified that cryptographic modules operate in their approved mode in accordance with relevant policies and procedures. |
| It shall be verified that there is an explicit policy for how cryptographic keys are managed (for example, generated, distributed, revoked, or expired), and that this policy is properly enforced. |
| It shall be verified that non-repudiation through cryptography (digital signing) is present for financial or e-commerce transactions and records. |
| It shall be verified that all cryptographic keys are adequately protected. If a key has been compromised, it shall no longer be trusted and shall be replaced or revoked. |
| It shall be verified that Personally Identifiable Information (PII) and protected information and data are stored encrypted at rest. || Integrity checks, such as digital signatures, shall be implemented on any serialized objects to prevent hostile object creation or data tampering. |
| Strict type constraints during deserialization shall be enforced before object creation as the code typically expects a definable set of classes. Bypasses to this technique have been demonstrated; therefore, reliance solely on this technique is not advisable. |
| Code that deserializes shall be isolated and run in low privilege environments whenever possible. |
| Deserialization exceptions and failures; such as the cases in which the incoming type is not the expected type, or the deserialization throws exceptions; shall be logged. |
| Incoming and outgoing network connectivity from containers or servers that deserialize shall be restricted or monitored.  |
| Deserialization shall be monitored, and an alert shall be issued if a user deserializes constantly. || For in-house developed software, explicit error checking shall be performed and documented for all input, including size, data type, and acceptable ranges or formats. |
| It shall be verified that the application does not output error messages or stack traces containing protected data that could assist an attacker, including a session ID and personal information. |
| It shall be verified that error handling is performed on trusted devices. |
| It shall be verified that all logging controls are implemented on the server. |
| It shall be verified that error handling logic in security controls denies access by default. |
| It shall be verified that security logging controls provide the ability to log both success and failure events that are identified as security-relevant. |
| It shall be verified that each log event includes a time stamp from a reliable source, severity level of the event, an indication that the event is a security relevant event (if mixed with other logs), the identity of the user that caused the event (if there is a user associated with the event), the source IP address of the request associated with the event, whether the event succeeded or failed, and a description of the event. |
| It shall be verified that all logs are protected from unauthorized access and modification. |
| It shall be verified that the application does not log application-specific protected data that could assist an attacker, including user’s session IDs and personal or protected information. |
| It shall be verified that a log analysis tool is available which allows an analyst to search for log events based on a combination of search criteria across all fields in the log record format supported by this system. |
| It shall be verified that all events that include untrusted data will not execute as code in the intended log viewing software. |
| It shall be verified that there is a single logging implementation that is used by the application. |
| It shall be verified that logs have a standard regular procedure for backing up or archiving. |
| “Try catch” shall be implemented where applicable. |
| It shall be verified that all the below logs are enabled: |
| Log of all input validation failures |
| Log of all authentication attempts, especially failures |
| Log of all access control failures |
| Log of all apparent tampering events, including unexpected changes to data status. |
| Log of attempts to connect with invalid or expired session tokens |
| Log of all system exceptions |
| Log of all administrative functions, including changes to the security configuration settings |
| Log of all backend TLS connection failures |
| Log of cryptographic module failures || It shall be verified that the application accepts only a defined set of HTTP request methods, such as GET and POST, and that unused methods are explicitly blocked |
| It shall be verified that every HTTP response contains a content type header specifying a safe character set (e.g., UTF-8). |
| It shall be verified that HTTP headers and/or other mechanisms for older browsers have been included to protect against click jacking attacks. |
| It shall be verified that HTTP headers in both requests and responses contain only printable ASCII characters. |
| The use of less complex data formats, such as JSON, shall be verified, and serialization of protected data shall be avoided |
| All XML processors and libraries in use by the application or on the underlying operating system shall be patched or upgraded. Additionally, dependency checkers shall be used,  and SOAP shall be updated to SOAP 1.2 or higher. |
| XML external entity and DTD processing shall be disabled in all XML parsers in the application, as per OWASP Cheat Sheet "XXE Prevention". |
| Positive server-side input validation (whitelisting), filtering, or sanitization shall be implemented to prevent hostile data within XML documents, headers, or nodes. |
| It shall be verified that XML or XSL file upload functionality validates incoming XML using XSD validation or similar. |
| SAST and DAST tools shall be used to help detect XXE in source code, although manual code review is the best alternative in large and complex applications with many integrations. |
| If the implementation of these controls is not possible, the use of virtual patching, API security gateways, or Web Application Firewalls (WAFs) shall be considered to detect, monitor, and block XXE attacks. || It shall be verified that the runtime environment is not susceptible to buffer overflows, and that security controls prevent buffer overflows. |
| It shall be verified that the runtime environment is not susceptible to SQL Injection, and that security controls prevent SQL Injection. |
| It shall be verified that the runtime environment is not susceptible to Cross Site Scripting (XSS), and that security controls prevent XSS. |
| It shall be verified that the runtime environment is not susceptible to LDAP Injection, and that security controls prevent LDAP Injection. |
| It shall be verified that the runtime environment is not susceptible to OS Command Injection, and that security controls prevent OS Command Injection. |
| Data type, range and length shall be verified (if possible).  |
| If any potentially hazardous characters must be allowed as input, additional controls; such as output encoding, secure task specific APIs, and accounting for the utilization of that data throughout the application; shall be implemented. Examples of common hazardous characters include: (: < > " ' % ( ) & + \\' \"). |
| It shall be verified that all input validation is carried out by a centralized input validation routine for the application. |
| It shall be verified that all input validation failures result in input rejection or input sanitization. |
| It shall be verified that all input validation or encoding routines are performed and enforced on the server side. |
| It shall be verified that all untrusted data that is output to HTML (including HTML elements, HTML attributes, JavaScript data values, CSS blocks, and URL attributes) is properly discarded for the applicable context. |
| It shall be verified that a character set, such as UTF-8, is specified for all sources of input. |
| It shall be verified that all input data is canonicalized for all downstream decoders or interpreters prior to validation. |
| If the application framework allows automatic mass parameter assignment (also called automatic variable binding) from the inbound request to a model, it shall be verified that security sensitive fields such as “accountBalance”, “role” or “password” are protected from malicious automatic binding. |
| It shall be verified that the application has defenses against HTTP parameter pollution attacks, particularly if the application framework makes no distinction about the source of request parameters (GET, POST, cookies, headers, environment, etc.) |
| It shall be verified that a single input validation control is used by the application for each type of data that is accepted. |
| It shall be verified that all input validation failures are logged. |
| It shall be verified that for each type of output encoding/escaping performed by the application, there is a single security control for that type of output for the intended destination. || It shall be verified that all pages and resources require authentication except those specifically intended to be public (Principle of Complete Mediation). |
| It shall be verified that all password fields do not show users' passwords when entered, and that password fields (or the forms that contain them) have autocomplete disabled. |
| It shall be verified that all authentication controls fail securely to ensure that attackers cannot log in. |
| It shall be verified that credentials and all other identity information handled by the application do not traverse unencrypted or through weakly encrypted links. |
| It shall be verified that forgot password and other recovery paths do not send the existing or new passwords in clear text to the user. |
| It shall be verified that performing username enumeration is not possible via login, password reset, or forgot account functionalities. |
| It shall be verified that there are no default passwords in use for the application framework or any components used by the application (such as “admin/password”). |
| It shall be verified that a resource governor is in place to protect against vertical brute forcing (i.e., when a single account is tested against all possible passwords) and horizontal brute forcing (i.e., when all accounts are tested with the same password, such as “Password1”). A correct credential entry shall incur no delay. For example, brute force source IP address lockout shall be configured to 60 minutes and account lockout to 15 minutes. Both these governor mechanisms shall be active simultaneously to protect against diagonal and distributed attacks. |
| It shall be verified that all authentication controls are enforced on the server side. |
| It shall be verified that password entry fields allow or encourage the use of passphrases, and do not prevent the entry of long passphrases or highly complex passwords and provide a sufficient minimum strength to protect against the use of commonly chosen passwords. |
| It shall be verified that all account management functions (such as registration, update profile, forgot username, forgot password, disabled/lost token, help desk or IVR) that might regain access to the account are at least as resistant to attacks as the primary authentication mechanism. |
| It shall be verified that users can safely change their credentials using a mechanism that is at least as resistant to attacks as the primary authentication mechanism. Password changes shall require the existing password to be entered prior to entering a new password, followed by re-authentication of the user. |
| It shall be verified that authentication credentials expire after an administratively configurable period of time. The password expiry duration shall be shorter based on the criticality of the application, thus ensuring a quicker password change. |
| It shall be verified that all authentication decisions are logged, including linear back offs and soft-locks. |
| It shall be verified that account passwords are salted using a salt that is unique to each account (e.g., internal user ID, account creation, etc.) and hashed before storing. |
| It shall be verified that all authentication credentials for accessing external services for the application are encrypted and stored in a protected location (not in source code). |
| It shall be verified that forgot password and other recovery paths send a time-limited activation token or use multi-factor authentication (e.g., SMS, tokens, mobile application, etc.) instead of a password. |
| It shall be verified that “forget password” functionality does not lock or otherwise disable the account until after the user has successfully changed their password. |
| It shall be verified that there are no shared knowledge questions/answers (Also called "secret" questions and answers). |
| It shall be verified that the system can be configured to disallow the use of a configurable number of previous passwords |
| It shall be verified that all authentication controls (including libraries that call external authentication services) have a centralized implementation. |
| It shall be verified that re-authentication, step up or adaptive authentication, SMS or other two-factor application, or transaction signing is required before any application-specific sensitive operations are permitted as per the risk profile of the application. |
| It shall be verified that a functionality to invalidate or disable user credentials in the event of a compromise is in place. |
| It shall be verified that password encryption is implemented in accordance with relevant standards and procedures. |
| If the application manages a credential store, it shall ensure that only cryptographically strong one-way salted hashes of passwords are stored and that the table/file that stores the passwords and keys is write-able only by the application. (If possible, MD5 algorithm shall not be used). |
| Authentication logic shall be segregated from the resource being requested, and redirection to and from the centralized authentication control shall be used. |
| Authentication failure responses shall not indicate which part of the authentication data is incorrect. For example, instead of "Invalid username" or "Invalid password", "Invalid username and/or password" shall be used for both. Error responses shall be truly identical in both display and source code. |
| Password complexity requirements established by a policy or regulation shall be enforced. Authentication credentials shall be sufficient to withstand attacks that are typical of the threats in the deployed environment. |
| Additionally, it shall be verified that passwords contain: |
| At least 1 upper case character (A-Z) |
| At least 1 lower case character (a-z) |
| At least 1 digit  (9-0) |
| At least 1 special character (e.g., “ !"#$%&'()*+,-/:;<=>?@[\]^_`{|}~”) |
| It shall be verified that passwords do not contain: |
| More than 2 identical digits or characters in a row (e.g., 111, aa, etc.) |
| Sequential digits or characters (e.g., 123, 789, and abc) |
| The same username |
| Dictionary words (e.g., password, p@ssw0rd, secret123, etc.) |
| Accounts shall be disabled after an established number of invalid login attempts (e.g., five attempts for non-critical applications and three attempts for critical applications). Accounts shall be disabled for a period of time sufficient to discourage brute force guessing of credentials, but not so long as to allow for a denial-of-service attack to be performed. (For example, disabled for 30 minutes). |
| The last use (successful or unsuccessful) of a user account shall be reported to the user at their next successful login. || It shall be verified that a path can be built from a trusted CA to each Transport Layer Security (TLS) server certificate, and that each server certificate is valid. |
| It shall be verified that the latest version of TLS is used for all connections (including both external and backend connections) that are authenticated or involve protected data or functions. |
| It shall be verified that backend TLS connection failures are logged. |
| It shall be verified that all connections to external systems that involve protected information or functions are authenticated. |
| It shall be verified that all connections to external systems that involve protected information or functions use an account that has been set up to have the minimum privileges necessary for the application to function properly. |
| It shall be verified that failed TLS connections do not fall back to an insecure connection. |
| It shall be verified that certificate paths are built and verified for all client certificates using configured trust anchors and revocation information. |
| It shall be verified that there is a single standard TLS implementation that is used by the application and configured to operate in an approved mode of operation. |
| It shall be verified that specific character encodings are defined for all connections (e.g., UTF-8). || It shall be verified that all forms containing protected information have disabled client side caching, including autocomplete features. |
| It shall be verified that all protected data is sent to the server in the HTTP message body (i.e., URL parameters shall never be used to send protected data). |
| It shall be verified that all cached or temporary copies of protected data stored on the server are protected from unauthorized access, and that those temporary working files are purged a soon as they are no longer required. |
| Client-side caching or temporary copies of pages containing protected data shall be disabled. Additionally, it shall be verified that such copies are protected from unauthorized access or purged/invalidated after an authorized user accesses the protected data). (Cache-Control: no-store, may be used in conjunction with HTTP header control "Pragma: no-cache", which is less effective, but is HTTP/1.0 backward compatible). |
| It shall be verified that the list of protected data processed by the application is identified, and that there is an explicit policy for how access to this data must be controlled, and when this data must be encrypted (both at rest and in transit). Additionally, it shall be verified that such policy is properly enforced. |
| It shall be verified that there is a method to remove each type of protected data from the application at the end of its required retention period. |
| It shall be verified that the application minimizes the number of parameters sent to untrusted systems, such as hidden fields, Ajax variables, cookies and header values. |
| It shall be verified that the application has the ability to detect and alert on abnormal numbers of requests for information, or on the processing of high value transactions for a user's role, such as screen scraping, automated use of web service extraction, or data loss prevention. For example, the average user shall not be able to access more than 5 records per hour or 30 records per day. |
| It shall be verified that credentials used by the application on the server side; such as database connection, password and encryption secret keys; are not hard coded. Any credentials shall be stored in a separate configuration file on a trusted system and shall be encrypted. |
| It shall be verified that autocomplete features are disabled on forms expected to contain protected information, including authentication. || It shall be verified that URL redirects and forwards do not include unvalidated data. |
| It shall be verified that filenames and path data obtained from untrusted sources are canonicalized to eliminate path traversal attacks. |
| It shall be verified that files obtained from untrusted sources are scanned by antivirus scanners to prevent the upload of known malicious content. |
| It shall be verified that parameters obtained from untrusted sources are not used in manipulating filenames, pathnames or any file system object without first being canonicalized and input validated to prevent local file inclusion attacks. |
| It shall be verified that parameters obtained from untrusted sources are canonicalized, input validated, and output encoded to prevent remote file inclusion attacks, particularly where input could be executed, such as header, source, or template inclusion. |
| It shall be verified that sharing remote IFRAMEs and HTML 5 resources across domains does not allow the inclusion of arbitrary remote content. |
| It shall be verified that files obtained from untrusted sources are stored outside the webroot. |
| It shall be verified that web or application server is configured by default to deny access to remote resources or systems outside the web or application server. |
| It shall be verified the application code does not execute uploaded data obtained from untrusted sources. |
| It shall be verified that Flash, Silverlight or other Rich Internet Application (RIA) cross-domain resource sharing configuration is set to prevent unauthenticated or unauthorized remote access. |
| It shall be verified that file types allowed for upload are limited to business purpose and needs only (e.g., PDF and office documents). |
| It shall be verified that file type validation is performed not only by checking file headers but also by checking file extension names. |
| It shall be verified that execution privileges are turned off on file upload directories. |
| It shall be verified that application files and resources are read-only by default. |
| It shall be verified that all unnecessary shares and administrative shares are removed, and that access to required shares is either restricted or requires authentication. |
| Authentication shall be required before allowing a file to be uploaded. |
| Size of files that can be uploaded shall be limited to the size that is needed for business purposes only (for example, maximum 1 MB), and a note shall be added on the web page for the accepted file sizes. || It shall be verified that no malicious code is in any code that was either developed or modified in order to create the application. |
| It shall be ensured that the integrity of interpreted code, libraries, executables, and configuration files is verified using checksums or hashes. |
| It shall be verified that all code implementing or using authentication controls is not affected by any malicious code. |
| It shall be verified that all code implementing or using session management controls is not affected by any malicious code. |
| It shall be verified that all code implementing or using access controls is not affected by any malicious code. |
| It shall be verified that all input validation controls are not affected by any malicious code. |
| It shall be verified that all code implementing or using output validation controls is not affected by any malicious code. |
| It shall be verified that all code supporting or using a cryptographic module is not affected by any malicious code. |
| It shall be verified that all code implementing or using error handling and logging controls is not affected by any malicious code. |
| It shall be verified all malicious activity is adequately sandboxed. |
| It shall be verified that protected data is rapidly sanitized from memory as soon as it is no longer needed. |
| Components shall be updated with the latest patches as soon as a user knows about published vulnerabilities. |
| Unused dependencies, unnecessary features, components, files, and documentation shall be removed. |
| Versions of both client-side and server-side components, (e.g., frameworks and libraries), and their dependencies shall be continuously inventoried using tools such as versions, DependencyCheck, retire.js, etc. Additionally, sources such as CVE and NVD, shall be continuously monitored for vulnerabilities in the components, and software composition analysis tools shall be used to automate the process. Subscription to email alerts for security vulnerabilities related to the used components shall be ensured as well. |
| Components shall be obtained from official sources and over secure links only. Signed packages shall be preferred to reduce the chance of including a modified, malicious component. |
| Libraries and components that are unmaintained or do not create security patches for older versions shall be monitored. If patching is not possible, deploying a virtual patch to monitor, detect, or protect against the discovered issue shall be considered. |