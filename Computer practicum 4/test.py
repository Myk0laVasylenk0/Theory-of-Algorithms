import numpy as np

# Given data
x = np.array([1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5])
x = x / 0.00012

y = np.array([0.008, 0.0098, 0.0113, 0.0137, 0.016, 0.0202, 0.0231, 0.0238])
# k = 5.88
N = len(y)

lambda_ = np.sum(x*y) / np.sum(x**2)
print("lambda:")
print(lambda_)


sigma_lambda = (1 / np.sqrt(N)) * np.sqrt(
    (np.sum(y**2)) / (np.sum(x**2)) - lambda_**2
)

print("sigma lambda:")
print(sigma_lambda)

print("")






x = np.array([0, 0.087, 0.161, 0.255, 0.332, 0.417, 0.501, 0.576])
y = np.array([0, 1, 2, 3, 4, 5, 6, 7]) * lambda_
N = len(x)

d = (np.sum(x*y) / np.sum(x**2))

print("d:")
print(d)

sigma_d = (1 / np.sqrt(N)) * np.sqrt(
    (np.sum(y**2)) / (np.sum(x**2)) - d**2
)

print("sigma d:")
print(sigma_d)
# Calculating σ_k using the provided formula


# print(sigma_k)

# x = np.array([1, 2, 3])
# y = np.array([4, 5, 6])
#
# z = np.sum(x*y)
#
# print(z)